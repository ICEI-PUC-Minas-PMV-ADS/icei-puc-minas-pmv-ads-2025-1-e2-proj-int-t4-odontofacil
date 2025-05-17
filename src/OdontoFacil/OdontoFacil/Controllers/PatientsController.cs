
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using OdontoFacil.Constants;
using OdontoFacil.Models.Views;
using OdontoFacil.Models.Data;
using OdontoFacil.Data;


namespace OdontoFacil.Controllers

{
    public class PatientsController(OdontoFacilDbContext context) : Controller
    {
        private readonly OdontoFacilDbContext _context = context;

        // GET: PATIENTS
        [Route("Paciente/{id}")]
        [HttpGet]
        public ActionResult Index(string id)
        {
            var patient = _context.Patients.Include(p => p.User).FirstOrDefault(p => p.Id == id);
            var notes = _context.Notes.Where(n => n.PatientId == id).ToList();
            var appointment = _context.Appointments.FirstOrDefault(a => a.PatientId == id);
            var user = patient.User;

            if (patient == null)
            {
                return NotFound();
            }

            var viewModel = new PatientViewModel
            {
                PatientId = patient.Id,
                Patient = patient,
                Name = patient.User.Name,
                DateOfBirth = patient.DateOfBirth,
                Age = CalculateAge(patient.DateOfBirth),
                Note = notes,
                Appointment = appointment

            };

            return View(viewModel);

        }
        private int CalculateAge(DateOnly? dateOfBirth)
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