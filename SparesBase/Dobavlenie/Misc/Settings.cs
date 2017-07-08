using System.IO;
using System.Xml;

namespace SparesBase
{
    static class Settings
    {
        public static bool AutoLoadItemImages { get; set; }

        // Создание файла настроек, если его нет
        public static void CreateConfigsFile()
        {
            if (!File.Exists("configs.xml"))
            {
                XmlDocument xDoc = new XmlDocument();
                XmlElement xRoot;

                xDoc.CreateXmlDeclaration("1.0", "UTF-8", "");
                xRoot = xDoc.CreateElement("SparesBase");

                // Автозагрузка картинок
                XmlElement autoLoadItemImages = xDoc.CreateElement("autoLoadItemImages");
                autoLoadItemImages.Attributes.Append(xDoc.CreateAttribute("value"));
                autoLoadItemImages.Attributes["value"].Value = AutoLoadItemImages == true ? "true" : "false";
                xRoot.AppendChild(autoLoadItemImages);

                xDoc.AppendChild(xRoot);
                xDoc.Save("configs.xml");
            }
        }

        // Сохранение настроек в файл
        public static void SaveSettings()
        {
            if (File.Exists("configs.xml"))
            {
                XmlDocument xDoc = new XmlDocument();
                XmlElement xRoot;

                xDoc.Load("configs.xml");
                xRoot = xDoc.DocumentElement;

                // Автозагрузка картинок
                xRoot["autoLoadItemImages"].Attributes["value"].Value = AutoLoadItemImages == true ? "true" : "false";

                xDoc.AppendChild(xRoot);
                xDoc.Save("configs.xml");
            }
        }

        // Загрузка настроек из файла
        public static void LoadSettings()
        {
            if (File.Exists("configs.xml"))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("configs.xml");
                XmlElement xRoot = xDoc.DocumentElement;

                AutoLoadItemImages = xRoot["autoLoadItemImages"].Attributes["value"].Value == "true" ? true : false;
            }
        }
    }
}
