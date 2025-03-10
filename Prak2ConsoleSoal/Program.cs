using System;
using System.IO;

// Adrian Aji Septa 22SA11A080
class Program
{
    static string filePathStreamWriter = "./output/nilai_mahasiswa_streamwriter.txt";
    static string filePathWriteAllLines = "./output/nilai_mahasiswa_writealllines.txt";

    static void Main()
    {
        Console.WriteLine("Menulis dan membaca file menggunakan StreamWriter:");
        WriteUsingStreamWriter();
        ReadFile(filePathStreamWriter);

        Console.WriteLine("\nMenulis dan membaca file menggunakan WriteAllLines:");
        WriteUsingWriteAllLines();
        ReadFile(filePathWriteAllLines);
    }

    static void WriteUsingStreamWriter()
    {
        using (StreamWriter writer = new StreamWriter(filePathStreamWriter))
        {
            writer.WriteLine("NIM, Nama, Mata Kuliah, Nilai");
            writer.WriteLine("220001, Andi, Algoritma, 85");
            writer.WriteLine("220002, Budi, Struktur Data, 90");
            writer.WriteLine("220003, Citra, Basis Data, 88");
        }
        Console.WriteLine("✅ Data berhasil ditulis dengan StreamWriter.");
    }

    static void WriteUsingWriteAllLines()
    {
        string[] data = {
            "NIM, Nama, Mata Kuliah, Nilai",
            "220001, Andi, Algoritma, 85",
            "220002, Budi, Struktur Data, 90",
            "220003, Citra, Basis Data, 88"
        };

        File.WriteAllLines(filePathWriteAllLines, data);
        Console.WriteLine("✅ Data berhasil ditulis dengan WriteAllLines.");
    }

    static void ReadFile(string filePath)
    {
        Console.WriteLine("\nIsi File (" + filePath + "):");
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("❌ File tidak ditemukan.");
        }
    }
}
