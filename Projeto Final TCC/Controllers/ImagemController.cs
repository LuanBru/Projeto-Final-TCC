using Microsoft.AspNetCore.Mvc;
using Projeto_Final_TCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Final_TCC.Controllers
{
    public class ImagemController : Controller
    {
        [HttpPost]
        public IActionResult Create(Fotos model)
        {
            if (ModelState.IsValid)
            {
                if (model.Imagem != null && model.Imagem.Length > 0)
                {
                    var foto = new Fotos
                    {
                        ID_Usuario = model.ID_Usuario,
                        ID_Animal = model.ID_Animal,
                        Longitude = model.Longitude,
                        Latitude = model.Latitude,
                        ID_Verificado = model.ID_Verificado,
                        Imagem = model.Imagem,
                        OBs = model.OBs
                    };

                    // Salvar o objeto 'foto' no banco de dados usando o Entity Framework Core

                    return RedirectToAction("Pricipal");
                }
            }

            return View(model);
        }
    }
}