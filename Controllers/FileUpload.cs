using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;


public class FileUpload : Controller
{
    // GET
    public IActionResult Index()
    {
        SingleFileModel model = new SingleFileModel();
        return View(model);
    }
    
    [HttpPost]
    public IActionResult Upload(SingleFileModel model)
    {
        if (ModelState.IsValid)
        {
            model.IsResponse = true;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(model.File.FileName);
            string fileName = model.FileName + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                model.File.CopyTo(stream);
            }
            model.IsSuccess = true;
            model.Message = "File upload successfully";
        }
        return View("Index", model);
    }
}