using System;

namespace Akeneo
{
    class Program
    {
        static void Main(string[] args)
        {
            Pyramid p = new Pyramid();
            string fileParth = FileLoader.GetFileFromUser();
            
            try
            {
                p.Load(FileLoader.ReadFile(fileParth));
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Invalid Pyramid file. Please enter a different pyramid");
            }

            p.GetSumsAndCounts();

        }

 
    }
}
