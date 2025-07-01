using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace WebDemo.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Ingreso desde Index";            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
