using System;
using System.Web;
using System.Web.Mvc;

namespace RPB.Website.UI.Controllers
{
    [ResponseCompressFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resume()
        {
            return View();
        }

        public ActionResult DownloadFile(string fileExtension)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Files/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + $"Rick_Bowman_Resume.{fileExtension}");
            string fileName = $"Rick_Bowman_Resume.{fileExtension}";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}