using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Ultilities.Results;

namespace Core.Ultilities.Helpers.FileHelper
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }

            var result = newPath(file);
            File.Move(sourcePath, result);
            return result;
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Delete(sourcePath);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result;

        }

        public static string newPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            string path = Environment.CurrentDirectory + @"\wwwroot\Uploads";
            var newPath = Guid.NewGuid().ToString("N") + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }    
}
