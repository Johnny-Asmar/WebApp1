using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageUploadController : ControllerBase
{
    public static IWebHostEnvironment _environment;
    
    public ImageUploadController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public class FileUploadAPI
    {
        public IFormFile files { get; set; }
    }
    
    [HttpPost]
    public async Task<string> Post([FromForm]FileUploadAPI objFile)
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