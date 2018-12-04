using ComApp.DAL;
using ComApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ComApp.Controllers
{
    public class ComController : Controller
    {
        private DataContext context = new DataContext();

        public ActionResult Index()
        {
            return View(context.ComData());
        }

        public ActionResult Upload()
        {
            var data = context.Upload();
            TempData["data"] = data;
            return View("Index", data);
        }

        public ActionResult Save()
        {   
            if(TempData["data"] != null)
            {
                var data = context.Save((List<ComData>)TempData["data"]);
                return View("Index", data);
            }
            return View("Index", context.ComData());
        }
    }
}