using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        string Upload(IFormFile formFile, string root);
        void Delete(string imagePath);
        string Update(IFormFile formFile, string filePath, string root);
    }
}
