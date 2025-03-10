using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Collections.Generic;

namespace Prak2Web.Pages
{
    public class TugasCModel : PageModel
    {
        private readonly ILogger<TugasCModel> _logger;
        private static readonly string defaultFilePath = "nilai_mahasiswa.txt";

        public TugasCModel(ILogger<TugasCModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public string? FilePath { get; set; }

        [BindProperty]
        public IFormFile? UploadedFile { get; set; }

        [BindProperty]
        public string? FileContents { get; set; }

        [BindProperty]
        public string? Message { get; set; }

        public void OnPostUpload()
        {
            if (UploadedFile != null)
            {
                using (var reader = new StreamReader(UploadedFile.OpenReadStream()))
                {
                    FileContents = reader.ReadToEnd();
                }

                HttpContext.Session.SetString("FileContents", FileContents); // Simpan ke session
                Message = "✅ File berhasil diunggah!";
            }
            else
            {
                Message = "⚠️ Silakan unggah file terlebih dahulu!";
            }
        }


        public void OnPostCreate()
        {
            FileContents = HttpContext.Session.GetString("FileContents"); // Ambil dari session

            if (string.IsNullOrWhiteSpace(FilePath))
            {
                Message = "⚠️ Silakan masukkan path untuk menyimpan file!";
                return;
            }

            if (string.IsNullOrWhiteSpace(FileContents))
            {
                Message = "⚠️ Tidak ada data untuk disimpan!";
                return;
            }

            List<string> lines = new() { "Mata Kuliah, Nilai" };

            foreach (var line in FileContents.Split('\n'))
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string mataKuliah = parts[0].Trim();
                    string nilai = parts[1].Trim();
                    lines.Add($"{mataKuliah}, {nilai}");
                }
            }

            System.IO.File.WriteAllLines(FilePath, lines);
            Message = "✅ Data berhasil disimpan!";
        }

    }
}
