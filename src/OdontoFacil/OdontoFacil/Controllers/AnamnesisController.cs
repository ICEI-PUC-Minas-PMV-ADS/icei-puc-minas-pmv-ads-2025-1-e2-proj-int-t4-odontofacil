using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoFacil.Data;
using OdontoFacil.Models.Views;
using OdontoFacil.Models.Data;
using static OdontoFacil.Models.Views.AnamneseViewModel;

namespace OdontoFacil.Controllers
{
    public class AnamnesisController : Controller
    {
        private readonly OdontoFacilDbContext _context;

        public AnamnesisController(OdontoFacilDbContext context)
        {
            _context = context;
        }

        [Route("/anaminese/{pacienteid}")]
        public async Task<IActionResult> Index(string pacienteId)
        {
            var perguntas = await _context.Database
           .SqlQuery<PerguntaResposta>($"""
            SELECT
              p.id AS PerguntaId,
              p.descricao AS Descricao,
              r.id AS Id,
              r.resposta AS Resposta,
              r.resposta_textual AS RespostaTextual
            FROM
              Pergunta_Anamnese p
              LEFT JOIN Resposta_Anamnese r
                ON p.id = r.id_pergunta
                AND r.id_paciente = {pacienteId}
            """).ToListAsync();

            var viewModel = new AnamneseViewModel
            {
                PacienteId = pacienteId,
                Perguntas = perguntas
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("/Anamnesis/SalvarAnamnese")]
        public async Task<IActionResult> Index(AnamneseViewModel model)
        {
            foreach (var item in model.Perguntas)
            {
                if (item.Resposta != null)
                {
                    var resposta = new AnamnesisAnswer
                    {
                       
                        PatientId = model.PacienteId,
                        QuestionId = item.PerguntaId,
                        Answer = item.Resposta ?? false,
                        TextAnswer = item.RespostaTextual
                    };

                    if (item.Id != null)
                    {
                        resposta.Id = item.Id;
                        _context.AnamnesisAnswers.Update(resposta);
                    }
                    else
                    {
                        resposta.Id = Guid.NewGuid().ToString();
                        _context.AnamnesisAnswers.Add(resposta);
                    }
                }
            }

            await _context.SaveChangesAsync();
            return Redirect($"/anaminese/{model.PacienteId}");
        }
    }
}
