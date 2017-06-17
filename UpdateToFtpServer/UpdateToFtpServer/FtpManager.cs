using BytesRoad.Net.Ftp;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace UpdateToFtpServer
{
    class FtpManager
    {
        // Данные об FTP сервере
        static int timeout = 30000;
        static int port = 21;
        static string server = "status.nvhost.ru";
        static string username = "sh61018001";
        static string password = "lfybkrf";
        static string remotePath = "SparesBase/";
        static FtpClient client;

        // Коннект к серверу
        private static void Connect()
        {
            client = new FtpClient();
            client.PassiveMode = true;
            client.Connect(timeout, server, port);
            client.Login(timeout, username, password);
        }


        public static ProgramVersion[] GetVersions(string programType)
        {
            List<ProgramVersion> versions = new List<ProgramVersion>();

            string path = programType + "/Versions/";

            Connect();
            string[] versionFolders = GetFilesFromServer(path);
            foreach (string folder in versionFolders)
            {
                byte[] versionBytes = client.GetFile(timeout, remotePath + path + folder + "/Version.xml");
                MemoryStream memStream = new MemoryStream(versionBytes);

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(memStream);
                XmlElement xRoot = xDoc.DocumentElement;

                versions.Add(new ProgramVersion(
                    xRoot["Version"].InnerText,
                    xRoot["Date"].InnerText,
                    xRoot["ChangeLog"].InnerText,
                    folder == "CurrentVersion" ? true : false));
            }
            client.Disconnect(timeout);

            return versions.ToArray();
        }

        public static void UploadNewVersion(string programType, ProgramVersion programVersion, string newVersionFilePath)
        {
            string path = programType + "/Versions/";
            Connect();

            // Перемещение старых версий файлов в другую папку
            byte[] versionBytes = client.GetFile(timeout, remotePath + path + "CurrentVersion/Version.xml");
            MemoryStream memStream = new MemoryStream(versionBytes);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(memStream);
            XmlElement xRoot = xDoc.DocumentElement;
            string oldVersion = xRoot["Version"].InnerText;

            client.CreateDirectory(timeout, remotePath + path + oldVersion);
            string[] oldVersionFiles = GetFilesFromServer(path + "CurrentVersion/");
            foreach (string file in oldVersionFiles)
            {
                // Перемещение старой версии файла в другую папку
                client.RenameFile(timeout, remotePath + path + "CurrentVersion/" + file, remotePath + path + oldVersion + "/" + file);
            }

            XmlDocument newVersionXml = new XmlDocument();
            newVersionXml.AppendChild(newVersionXml.CreateXmlDeclaration("1.0", "UTF-8", ""));
            XmlElement newVersionRoot = newVersionXml.CreateElement("SparesBase");

            XmlNode versionNode = newVersionXml.CreateElement("Version");
            versionNode.InnerText = programVersion.Version;
            newVersionRoot.AppendChild(versionNode);

            XmlNode dateNode = newVersionXml.CreateElement("Date");
            dateNode.InnerText = programVersion.Date;
            newVersionRoot.AppendChild(dateNode);

            XmlNode changeLogNode = newVersionXml.CreateElement("ChangeLog");
            changeLogNode.InnerText = programVersion.ChangeLog;
            newVersionRoot.AppendChild(changeLogNode);

            newVersionXml.AppendChild(newVersionRoot);

            newVersionXml.Save("Version.xml");

            client.PutFile(timeout, remotePath + path + "CurrentVersion/Version.xml", File.ReadAllBytes("Version.xml"));

            byte[] fileBytes = File.ReadAllBytes(newVersionFilePath);
            MemoryStream str = new MemoryStream(fileBytes);
            client.PutFile(timeout, remotePath + path + "CurrentVersion/" + (programType == "Client" ? "SparesBase.exe" : "SparesBaseAdministrator.exe"), str);
            client.Disconnect(timeout);
        }

        // Получение файлов с сервера по определенному пути
        private static string[] GetFilesFromServer(string path)
        {
            FtpItem[] files = client.GetDirectoryList(timeout, remotePath + path);
            List<string> names = new List<string>();
            for (int i = 0; i < files.Length; i++)
                if (files[i].Name != "." && files[i].Name != "..")
                    names.Add(files[i].Name);

            return names.ToArray();
        }
    }
}
