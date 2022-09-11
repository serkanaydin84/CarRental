using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileManager:IFileHelper
    {
        public string Upload(IFormFile formFile, string root)
        {
            if (formFile != null)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string imageExtension = Path.GetExtension(formFile.FileName);
                string imageName = Guid.NewGuid().ToString() + imageExtension;
                using (FileStream fileStream=File.Create(root+imageName))
                {
                    formFile.CopyTo(fileStream);
                    fileStream.Flush();
                    return imageName;
                }
            }

            return null;
        }

        public void Delete(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }

        public string Update(IFormFile formFile, string imagePath, string root)
        {
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            return Upload(formFile, root);
        }
    }
}
