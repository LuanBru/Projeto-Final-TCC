﻿using System.IO;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Projeto_Final_TCC.Models;


namespace Projeto_Final_TCC.Controllers
{
    public class FotosController : Controller
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

                    return RedirectToAction("Principal");
                }
            }

            return View(model);
        }
    }
}