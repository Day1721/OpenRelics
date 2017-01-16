using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using OpenRelicsWebApp.Models;

namespace OpenRelicsWebApp.Controllers
{
    public class RelicsController : Controller
    {
        private readonly DbAccessor _accessor = new DbAccessor();

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
            System.Diagnostics.Debug.WriteLine(AppDomain.CurrentDomain.GetData("DataDirectory"));
            /*
            ViewBag.ToMethod = new Dictionary<string, string>
            {
                {"Get by ID", "GetById"},
                {"Get direct descendants", "GetDirectDescendants"},
                {"Get all descendants", "GetAllDescendants"},
                {"Get all relics from given region", "GetAllFromRegion"}
            };*/
            return View(Queries);
        }

        public ActionResult GetById(int id)
        {
            return View(_accessor.GetById(id));
        }

        public ActionResult GetDirectDescendants(int id)
        {
            var check = _accessor.GetById(id);

            if (check == null)
                return View("GetDescendants", null);

            return View("GetDescendants", _accessor.GetDirectDescendants(id));
        }

        public ActionResult GetAllDescendants(int id)
        {
            var check = _accessor.GetById(id);

            if (check == null)
                return View("GetDescendants", null);

            return View("GetDescendants", _accessor.GetAllDescendants(id));
        }

        public ActionResult GetAllFromRegion([FromUri] LocationViewModel model)
        {
            if (ModelState.IsValid)
                return View(_accessor.GetAllFromRegion(model));

            return View(null as IQueryable<int>);
        }
    }
}