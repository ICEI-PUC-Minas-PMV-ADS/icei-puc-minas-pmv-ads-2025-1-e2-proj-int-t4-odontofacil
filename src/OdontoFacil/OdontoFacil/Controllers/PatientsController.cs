using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using OdontoFacil.Constants;
using OdontoFacil.Models.Views;
using OdontoFacil.Models.Data;
using OdontoFacil.Data;
using System.Linq;

namespace OdontoFacil.Controllers
{
    [Authorize(Roles = UserTypes.Dentist + "," + UserTypes.ClassHelper)] // Aplica a autorização a toda a controller
    public class PatientsController(OdontoFacilDbContext context) : Controller
    {
        private readonly OdontoFacilDbContext _context = context;

        [Route("Pacientes")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var patients = await _context.Patients
                .Include(p => p.User)
                .ToListAsync();

            var patientListViewModels = patients.Select(p => new PatientListViewModel
            {
                Id = p.Id,
                Name = p.User.Name,
                CPF = p.User.CPF,
                Age = CalculateAge(p.DateOfBirth)
            }).ToList();

            return View("List", patientListViewModels); // Especifica o nome da View
        }

        // GET: PATIENTS
        [Route("Paciente/{id}")]
        [HttpGet]
        public ActionResult Index(string id)
        {
            var patient = _context.Patients.Include(p => p.User).FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            var notes = _context.Notes.Where(n => n.PatientId == id).ToList();
            var appointment = _context.Appointments.FirstOrDefault(a => a.PatientId == id);
            var user = patient.User;



            var viewModel = new PatientViewModel
            {
                PatientId = patient.Id,
                Patient = patient,
                Name = patient.User.Name,
                DateOfBirth = patient.DateOfBirth,
                Age = CalculateAge(patient.DateOfBirth),
                Note = notes,
                Appointment = appointment,
            };

            return View(viewModel);
        }

        private static int CalculateAge(DateOnly? dateOfBirth)
        {
            if (!dateOfBirth.HasValue)
                return 0;

            var today = DateOnly.FromDateTime(DateTime.Now);
            int age = today.Year - dateOfBirth.Value.Year;

            if (today < dateOfBirth.Value.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}