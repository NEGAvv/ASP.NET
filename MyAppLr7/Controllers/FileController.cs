using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAppLr7.Models;
using System.Diagnostics;
using System.Text;


namespace MyAppLr7.Controllers
{
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        public FileController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var fileNames = Directory.GetFiles(Path.Combine(_environment.WebRootPath, "Files"))
               .Select(Path.GetFileName)
               .ToList();

            ViewBag.FileList = fileNames;

            return View();
        }

        [HttpPost]
        public ActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            string content = $"First Name: {firstName}\nLast Name: {lastName}";
            string fileNameWithExtension = fileName + ".txt";
            string webRootPath = _environment.WebRootPath;
            string filePath = Path.Combine(webRootPath, "Files", fileNameWithExtension);
            System.IO.File.WriteAllText(filePath, content, Encoding.UTF8);

            return PhysicalFile(filePath, "text/plain", fileNameWithExtension);
        }

        [HttpPost]
        public IActionResult ViewFile(string selectedFile)
        {
            string webRootPath = _environment.WebRootPath;
            string filePath = Path.Combine(webRootPath, "Files", selectedFile);

            if (System.IO.File.Exists(filePath))
            {
                string fileContent = System.IO.File.ReadAllText(filePath, Encoding.UTF8);
                ViewBag.SelectedFileContent = fileContent;
            }
            else
            {
                ViewBag.SelectedFileContent = "File not found.";
            }

            //To view another files in select
            var fileNames = Directory.GetFiles(Path.Combine(_environment.WebRootPath, "Files"))
               .Select(Path.GetFileName)
               .ToList();
            ViewBag.FileList = fileNames;

            return View("DownloadFile");
        }
    }
}