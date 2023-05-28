using Projeto_Final_TCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Final_TCC.Controllers
{
    public class CadastroController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Lógica para salvar o usuário no banco de dados
                // (Você pode usar um ORM como Entity Framework ou Dapper)

                return RedirectToAction("Index", "Home");
            }

            return View(usuario);
        }
    }
}
        