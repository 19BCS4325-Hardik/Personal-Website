using RPB.Website.BL;
using System.Web.Mvc;

namespace RPB.Website.UI.Controllers
{
    public class PersonalProjectController : Controller
    {
        PersonalProjectList projects;

        public ActionResult Index()
        {
            projects = new PersonalProjectList();
            projects.Load();
            return View(projects);
        }

        public ActionResult Create()
        {
            if (Session["user"] != null)
            {
                PersonalProject project = new PersonalProject();
                return View(project);
            }
            else
                return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Create(PersonalProject project)
        {
            if (Session["user"] != null)
            {
                try
                {
                    project.Insert();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(project);
                }
            }
            else
                return RedirectToAction("Login", "Login");            
        }

        public ActionResult Edit(int id)
        {
            if (Session["user"] != null)
            {
                PersonalProject project = new PersonalProject();
                project.Id = id;
                project.LoadById();
                return View(project);
            }
            else
                return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Edit(int id, PersonalProject project)
        {
            if (Session["user"] != null)
            {
                try
                {
                    project.Update();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(project);
                }
            }
            else
                return RedirectToAction("Login", "Login");
        }

        public ActionResult Delete(int id)
        {
            if (Session["user"] != null)
            {
                PersonalProject project = new PersonalProject();
                project.Id = id;
                project.LoadById();
                return View(project);
            }
            else
                return RedirectToAction("Login", "Login");
            
        }

        [HttpPost]
        public ActionResult Delete(int id, PersonalProject project)
        {
            if (Session["user"] != null)
            {
                try
                {
                    project.Delete();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(project);
                }
            }
            else
                return RedirectToAction("Login", "Login");            
        }
    }
}
