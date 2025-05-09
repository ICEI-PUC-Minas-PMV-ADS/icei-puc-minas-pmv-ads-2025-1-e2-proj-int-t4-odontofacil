using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OdontoFacil.Models;
using OdontoFacil.Models.ViewModels;

namespace OdontoFacil.Controllers
{
    public class PerfilPacienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Historico()
        {
            var consultas = new List<ConsultaViewModel>
    {
        new() { Data = new DateTime(2025, 4, 2), Status = "Aguardando", LinkDocumento = "#" },
        new() { Data = new DateTime(2025, 2, 16), Status = "Pronto", LinkDocumento = "#" },

    };

            return View(consultas);
        }
        [HttpGet]
        public IActionResult Anamnese()
        {
            var model = new AnamneseViewModel(); // Carregar dados do banco se houver
            return View(model);
        }

        // POST: Prontuario/Anamnese
        [HttpPost]
        public IActionResult SalvarAnamnese(AnamneseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Anamnese", model);
            }

            // TODO: Salvar os dados no banco de dados aqui
            TempData["Mensagem"] = "Anamnese salva com sucesso!";
            return RedirectToAction("Anamnese");
        }
    }
}
