using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string process = args[0].Replace(".exe", "");

                Console.WriteLine("Удаление процессов...");
                Console.WriteLine(process);
                while (Process.GetProcessesByName(process).Length > 0)
                {
                    Process[] myProcesses2 = Process.GetProcessesByName(process);
                    for (int i = 0; i < myProcesses2.Length; i++)
                        myProcesses2[i].Kill();

                    Thread.Sleep(300);
                }

                Console.WriteLine("Удаление оригинального файла...");
                if (File.Exists(args[0]))
                    File.Delete(args[0]);

                Console.WriteLine("Копирование файла обновления...");
                File.Move(args[1], args[0]);

                Console.WriteLine("Удаление файла обновления...");
                if (File.Exists(args[1]))
                    File.Delete(args[1]);

                Console.WriteLine("Запуск программы " + args[0] + "...");
                Process.Start(args[0]);
            }
        }
    }
}
