using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Final_TCC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Principal()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Cadastro()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Solicitacao()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}