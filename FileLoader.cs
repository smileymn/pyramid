using System;
using System.IO;

namespace Akeneo
{
    public class FileLoader
    {
        public static string GetFileFromUser()
        {
            string path = string.Empty;
            bool validFilePath = false;
            while (!validFilePath)
            {
                Console.WriteLine("Please enter path of pyramid text file:");
                Console.WriteLine(@"Example: C:\Users\JohnSnow\Documents\input.txt");

                path = Console.ReadLine();
                if (File.Exists(path))
                {
                    validFilePath = true;
                    Console.WriteLine("File Acceped. Processing...");
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Invalid file path");

                }
            }


            return path;
        }

        public static string[] ReadFile(string filePath)
        {
            // Read a text file line by line.  
            string path = @"C:\Users\Michal\Documents\Work\code\Akeneo\input.txt";
            string[] lines = File.ReadAllLines(filePath);
            return lines;
        }
    }
}
