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

        public ActionResult WorkHistory()
        {
            return View();
        }

        public ActionResult Education()
        {
            return View();
        }

        public ActionResult AboutMe()
        {
            return View();
        }
    }
}