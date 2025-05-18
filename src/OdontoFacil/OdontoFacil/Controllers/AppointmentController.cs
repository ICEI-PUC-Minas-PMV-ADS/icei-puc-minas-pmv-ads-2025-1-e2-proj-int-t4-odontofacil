using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoFacil.Data;
using OdontoFacil.Models.Views;

namespace OdontoFacil.Controllers;

public class AppointmentController : Controller
{

    private readonly OdontoFacilDbContext _dbContext;

    public AppointmentController(OdontoFacilDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("Agendar")]
    public async Task<IActionResult> Create()
    {
        // TODO: Retornar pacientes caso o usuário logado seja dentista ou operador
        //TODO: filtrar por especialidade
        var dentists = await _dbContext.Dentists
            .Include(dentist => dentist.User)
            .ToListAsync();

        ViewBag.Dentists = dentists;

        return View();
    }

    [Route("appointment/unavailableDates/{dentistId}")]
    public async Task<IActionResult> GetUnvailableDates(string dentistId)
    {
        var dates = await _dbContext.Database
            .SqlQuery<DateOnly>($"""
                SELECT data FROM "Atendimento"
                JOIN "Dentista" ON "Atendimento".id_dentista = "Dentista".id
                WHERE 
                    data > now()
                    AND EXTRACT(HOUR FROM hora) BETWEEN 9 AND 18
                    AND "Dentista".id = {dentistId} 
                GROUP BY data
                    HAVING COUNT(DISTINCT EXTRACT(HOUR FROM hora)) = 10;
            """).ToListAsync();

        return Ok(dates);
    }

    [Route("appointment/unavailableHours/{dentistId}/{date}")]
    public async Task<IActionResult> GetUnvailableDates(string dentistId, string date)
    {
        var parsedDate = DateOnly.Parse(date);
        var hours = await _dbContext.Appointments
            .Include(appointment => appointment.Dentist)
            .Where(
                appointment =>
                appointment.Date == parsedDate &&
                appointment.DentistId == dentistId
            )
            .Select(appointment => appointment.Hour)
            .ToListAsync();

        return Ok(hours);
    }

    // POST: /appointment/Create
    [HttpPost]
    public IActionResult Create(ScheduleAppointmentViewModel formData)
    {
        if (ModelState.IsValid)
        {
            // TODO: Inserir no banco
            // TODO: Redirecionar para a tela de agendamentos
            return RedirectToAction(nameof(Index));
        }
        return View(formData);
    }
}