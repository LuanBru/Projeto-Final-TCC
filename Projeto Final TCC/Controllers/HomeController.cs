using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Final_TCC.Controllers
{
    public class HomeController : Controller
    {
        private static string ApiKey = "yJUnCCy336Gn9KNW7DEDcAyTZ1Z8t0gqiy623oNi";
        private static string AuthEmail = "";
        private static string AuthPassword = "";
        private static string Bucket = "gs://asp-mvc-with-android.appspot.com";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}