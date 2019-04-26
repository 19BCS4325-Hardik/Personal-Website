using RPB.Website.BL;
using System;
using System.Web.Mvc;

namespace RPB.Website.UI.Controllers
{
    [ResponseCompressFilter]
    public class LoginController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                if (user.Login())
                {
                    Session["user"] = user;
                    return RedirectToAction("Index", "PersonalProject");
                }
                else
                {
                    ViewBag.Message = "Incorrect username or password.";
                    return View(user);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
