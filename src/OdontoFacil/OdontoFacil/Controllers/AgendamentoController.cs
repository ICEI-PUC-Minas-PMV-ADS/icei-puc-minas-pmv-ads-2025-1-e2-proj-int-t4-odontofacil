using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OdontoFacil.Models;

namespace OdontoFacil.Controllers
{
    public class AgendamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    

    public IActionResult Resultado(string especialidade, string local)
        {
            // Simulando um retorno (futuramente será do banco de dados)
            DentistaViewModel dentista = new DentistaViewModel
            {
                Nome = "Doutura M Clara Moura",
                Especialidade = "Clínico Geral",
                Endereco = "Belo Horizonte, Minas Gerais\nAv. Getúlio Vargas 1500 - Savassi - 30112-024",
                DiasDisponiveis = new Dictionary<string, List<string>>
        {
            { "Terça", new List<string> { "09:30", "10:00", "10:30" } },
            { "Quarta", new List<string> { "09:30", "10:00", "10:30" } },
            { "Quinta", new List<string> { "09:30", "10:00", "10:30" } },
        }
            };

            return View(dentista);
        }
    }
}