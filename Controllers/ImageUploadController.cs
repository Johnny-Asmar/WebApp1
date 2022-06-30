using Microsoft.AspNetCore.Mvc;
using WebApplication1.Abstraction;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageUploadController : ControllerBase
{
    private  IUploadImageHelper _uploadImageHelper;
    
    public ImageUploadController(IUploadImageHelper uploadImageHelper)
    {
        _uploadImageHelper = uploadImageHelper;
    }
    
    [HttpPost]
    public async Task<string> Post([FromForm]FileUploadAPI objFile)
    {
        return _uploadImageHelper.UploadImage(objFile);
    }
}