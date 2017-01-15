using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OpenRelicsWebApp.Controllers
{
    public class RelicsController : Controller
    {
        internal static readonly List<string> Queries = new List<string>
        {
            "Get by ID",
            "Get direct descendants",
            "Get all descendants",
            "Get all relics from given region"
        };

        public ActionResult Index()
        {
            ViewBag.Title = "Open relics";
            return View(Queries);
        }
    }
}