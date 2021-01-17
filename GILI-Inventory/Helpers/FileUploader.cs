using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GILI_Inventory.Helpers
{
    public static class FileUploader
    {
        public static string UploadFile(IFormFile file, IWebHostEnvironment webHostEnvironment)
        {
            string path = "";
            try
            {
                if (file != null && file.Length > 0)
                {
                    string name = Path.GetFileNameWithoutExtension(file.FileName);
                    string ext = Path.GetExtension(file.FileName);
                    string fileIndex = GenerateFileIndex();
                    CheckAndCreateDirectory($"Uploads/{fileIndex}", webHostEnvironment);
                    name = FileVersionCheckAndUpdate(name, $"Uploads/{fileIndex}", ext, webHostEnvironment);
                    string uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "Uploads", fileIndex + name + ext);
                    path = Path.Combine("/Uploads", fileIndex + name + ext);
                    using (var stream = File.Create(uploadPath))
                    {
                        file.CopyTo(stream);
                    }
                }
                return path;
            }
            catch (Exception)
            {
                return path;
            }
        }

        private static string GenerateFileIndex()
        {
            return DateTime.Now.Year + "/" + DateTime.Now.Month + "/";
        }

        private static void CheckAndCreateDirectory(string path, IWebHostEnvironment webHostEnvironment)
        {
            bool exist = Directory.Exists(Path.Combine(webHostEnvironment.WebRootPath, path));
            if (!exist)
                Directory.CreateDirectory(Path.Combine(webHostEnvironment.WebRootPath, path));
        }

        private static string FileVersionCheckAndUpdate(string fileName, string path, string ext, IWebHostEnvironment webHostEnvironment)
        {
            int count = 0;
            string newFileName = fileName;
            string newPath = Path.Combine(path, fileName + ext);
            while (File.Exists(Path.Combine(webHostEnvironment.WebRootPath, newPath)))
            {
                newFileName = string.Format("{0}({1})", fileName, ++count);
                newPath = Path.Combine(path, newFileName + ext);
            }
            return newFileName;
        }

    }
}