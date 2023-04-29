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
        [HttpGet]
        public ActionResult Cadastro()
        {
            return View(new Usuario());
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario model)
        {
            if (model.V_Biologo && string.IsNullOrEmpty(model.ID_Bio))
            {
                ModelState.AddModelError(nameof(model.ID_Bio), "O ID do biólogo é obrigatório.");
            }

            if (!ModelState.IsValid)
            {
                return View("Cadastro", model);
            }

            // Aqui você pode inserir a lógica para salvar os dados do cadastro no banco de dados.

            return RedirectToAction("Index", "Home");
        }
    }
    }