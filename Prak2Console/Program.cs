using System;
using System.IO;

namespace PRAK2CONSOLE
//ADRIAN AJI SEPTA 22SA11A080-
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = @"./output/";
            string fileName = "band.txt";
            string fullPath = folder + fileName;

            // Menggunakan StreamWriter untuk menulis ke file
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine("Bondan Prakoso");
                writer.WriteLine("Ariel Peterpan");
                writer.WriteLine("Andika Kangenband");
                writer.WriteLine("Pasha Ungu");
                writer.WriteLine("Didi Kempot");
            }

            string readText = File.ReadAllText(fullPath);
            Console.WriteLine(readText);


            // Menggunakan Array
            // string[] band = { "Didi Kempot", "Ariel Peterpan", "Andika Kangenband", "Pasha Ungu", "Bondan Prakoso" };
            // File.WriteAllLines(fullPath, band);

            // string readText = File.ReadAllText(fullPath);
            // Console.WriteLine(readText);
        }
    }
}
