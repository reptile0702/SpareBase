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
                while (Process.GetProcessesByName(process).Length > 0)
                {
                    Process[] myProcesses2 = Process.GetProcessesByName(process);
                    for (int i = 0; i < myProcesses2.Length; i++)
                        myProcesses2[i].Kill();

                    Thread.Sleep(300);
                }

                Console.WriteLine("Удаление оригинального файла...");
                File.Move(args[0], args[0] + ".bak");

                Console.WriteLine("Копирование файла обновления...");
                File.Move(args[1], args[0]);

                Console.WriteLine("Удаление файла обновления...");
                File.Delete(args[0] + ".bak");

                Console.WriteLine("Запуск программы " + args[0] + "...");
                Process.Start(args[0]);
            }
        }
    }
}
