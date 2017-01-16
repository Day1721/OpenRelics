using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenRelicsWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Open Relics MVC & Web API";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact information:";

            return View();
        }
    }
}