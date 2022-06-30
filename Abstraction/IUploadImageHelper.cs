using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Abstraction;

public interface IUploadImageHelper
{
    public string UploadImage(FileUploadAPI objFile);

}