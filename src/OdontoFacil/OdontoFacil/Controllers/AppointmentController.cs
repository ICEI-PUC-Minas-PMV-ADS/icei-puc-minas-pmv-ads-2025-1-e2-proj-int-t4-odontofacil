using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoFacil.Constants;
using OdontoFacil.Data;
using OdontoFacil.Models.Data;
using OdontoFacil.Models.Views;

namespace OdontoFacil.Controllers;

[Authorize]
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
        var viewModel = new ScheduleAppointmentViewModel { };
        var dentists = await _dbContext.Dentists
            .Include(dentist => dentist.User)
            .OrderBy(dentist => dentist.User.Name)
            .ToListAsync();

        ViewBag.Dentists = dentists;

        if (ShouldAllowUserIdChoice())
        {
            var users = await _dbContext.Users
                .Where(user => user.UserType == UserTypes.Patient)
                .OrderBy(user => user.Name)
                .ToListAsync();
            ViewBag.Users = users;
        }
        else
        {
            viewModel.UserId = GetUserIdFromSession();
        }

        return View(viewModel);
    }

    [Route("appointment/unavailableDates/{dentistId}")]
    public async Task<IActionResult> GetUnavailableDates(string dentistId)
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
    public async Task<IActionResult> GetUnavailableDates(string dentistId, string date)
    {
        var parsedDate = DateOnly.Parse(date);
        var hours = await _dbContext.Appointments
            .Include(appointment => appointment.Dentist)
            .Where(
                appointment =>
                appointment.Date == parsedDate &&
                appointment.DentistId == dentistId
            )
            .Select(appointment => appointment.Hour.ToString("HH:mm"))
            .ToListAsync();

        return Ok(hours);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(ScheduleAppointmentViewModel formData)
    {
        if (ModelState.IsValid)
        {
            var UserId = ShouldAllowUserIdChoice() ? formData.UserId : GetUserIdFromSession();
            var appointment = new Appointment
            {
                Id = Guid.NewGuid().ToString(),
                DentistId = formData.DentistId,
                Date = DateOnly.Parse(formData.Date, new CultureInfo("pt-BR")),
                Hour = TimeOnly.Parse(formData.Time),
                PatientId = UserId
            };
            _dbContext.Appointments.Add(appointment);
            await _dbContext.SaveChangesAsync();
            return Redirect("/Agendamentos");
        }

        return View(formData);
    }

    private bool ShouldAllowUserIdChoice()
    {
        return User.IsInRole(UserTypes.Dentist) || User.IsInRole(UserTypes.Helper);
    }

    private string GetUserIdFromSession()
    {
        var userId = User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
        return userId!;
    }
}