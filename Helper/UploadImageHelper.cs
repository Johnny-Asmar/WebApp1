using WebApplication1.Abstraction;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Helper;

public class UploadImageHelper : IUploadImageHelper
{
    
    public static IWebHostEnvironment _environment;

    public UploadImageHelper(IWebHostEnvironment environment)
    {
        _environment = environment;
    }
    public string UploadImage(FileUploadAPI objFile)
    {
        
        if (objFile.files.Length > 0)
        {
            try
            {
                if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                }

                using (FileStream fileStream =
                       System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                {
                    objFile.files.CopyTo(fileStream);
                    fileStream.Flush();
                    return "\\Upload\\" + objFile.files.FileName;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        else
        {
            return "Failed";
        }
    }
}