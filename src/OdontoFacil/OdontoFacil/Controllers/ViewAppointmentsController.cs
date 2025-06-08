
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using OdontoFacil.Constants;
using OdontoFacil.Models.Views;
using OdontoFacil.Models.Data;
using OdontoFacil.Data;


namespace OdontoFacil.Controllers

{
    public class ViewAppointmentsController(OdontoFacilDbContext context) : Controller
    {
        private readonly OdontoFacilDbContext _context = context;

        [Authorize(Roles = $"{UserTypes.Dentist}, {UserTypes.Helper}")]
        [Route("Paciente")]
        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {


            ViewData["Title"] = "Todos os Agendamentos";
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;

            IQueryable<Patient> patientsQuery = _context.Patients
                                                    .Include(p => p.User);

            if (!string.IsNullOrEmpty(searchString))
            {
                patientsQuery = patientsQuery.Where(p => p.User.Name.Contains(searchString));
            }

            var patients = await patientsQuery.ToListAsync();

            var allAppointmentsViewModel = new List<ViewAppointmentsViewModel>();

            foreach (var patient in patients)
            {
                var appointmentsForPatient = await _context.Appointments
                    .Where(a => a.PatientId == patient.Id)
                    .Include(a => a.Dentist)
                        .ThenInclude(d => d.User)
                    .ToListAsync();

                foreach (var appointment in appointmentsForPatient)
                {
                    allAppointmentsViewModel.Add(new ViewAppointmentsViewModel
                    {
                        AppointmentId = appointment.Id,
                        Date = appointment.Date,
                        Time = appointment.Time,
                        DentistName = appointment.Dentist?.User?.Name,
                        PatientName = patient.User?.Name,
                        Age = CalculateAge(patient.DateOfBirth), 
                        PatientId = patient.Id 
                    });
                }
            }

            string nextSortOrderForDate = "date_asc";
            string dateSortIconHtml ="";
            string nextSortOrderForTime = "time_asc";
            string timeSortIconHtml = "";

            IEnumerable<ViewAppointmentsViewModel> sortedAppointments = allAppointmentsViewModel;

            if (sortOrder == "date_desc")
            {
                sortedAppointments = allAppointmentsViewModel
                                        .OrderByDescending(vm => vm.Date)
                                        .ThenByDescending(vm => vm.Time)
                                        .ThenBy(vm => vm.PatientName);
                dateSortIconHtml = "&#9660;";
                nextSortOrderForDate = "date_asc";
            }
            else if (sortOrder == "date_asc")
            {
                sortedAppointments = allAppointmentsViewModel
                                        .OrderBy(vm => vm.Date)
                                        .ThenBy(vm => vm.Time)
                                        .ThenBy(vm => vm.PatientName);
                dateSortIconHtml = "&#9650;";
                nextSortOrderForDate = "date_desc";
            }

            else if (sortOrder == "time_desc")
            {
                sortedAppointments = allAppointmentsViewModel
                                        .OrderByDescending(vm => vm.Time)
                                        .ThenByDescending(vm => vm.Date)
                                        .ThenBy(vm => vm.PatientName);
                timeSortIconHtml = "&#9660;";
                nextSortOrderForTime = "time_asc";
            }
            else if (sortOrder == "time_asc")
            {
                sortedAppointments = allAppointmentsViewModel
                                        .OrderBy(vm => vm.Time)
                                        .ThenBy(vm => vm.Date)
                                        .ThenBy(vm => vm.PatientName);
                timeSortIconHtml = "&#9650;";
                nextSortOrderForTime = "time_desc"; 
            }
            else
            {
                sortedAppointments = allAppointmentsViewModel
                                        .OrderBy(vm => vm.Date)
                                        .ThenBy(vm => vm.Time)
                                        .ThenBy(vm => vm.PatientName);
                dateSortIconHtml = "&#9650;";
                nextSortOrderForDate = "date_desc";
            }

            ViewData["DateSortParam"] = nextSortOrderForDate;
            ViewData["DateSortIcon"] = dateSortIconHtml;
            ViewData["TimeSortParam"] = nextSortOrderForTime;
            ViewData["TimeSortIcon"] = timeSortIconHtml;
          
            return View(sortedAppointments.ToList());
        }

        [Authorize(Roles = $"{UserTypes.Dentist}, {UserTypes.Helper}, {UserTypes.Patient}")]
        [Route("Paciente/{id}")]
        [HttpGet]
        public async Task<IActionResult> SinglePatient(string id)
        {
            var authenticatedUserId = GetAuthenticatedUserId();
            var authenticatedUserRole = GetAuthenticatedUserRole();

            if (string.IsNullOrEmpty(authenticatedUserId) || string.IsNullOrEmpty(authenticatedUserRole))
            {
                return Unauthorized("Não foi possível obter o usuário autenticado.");
            }

            if (authenticatedUserRole == UserTypes.Patient && authenticatedUserId != id)
            {
                return Forbid("Você não tem permissão para acessar esse paciente.");
            }
        
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id de Paciente Inválido.");
            }

            var patient = await _context.Patients
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return NotFound("Paciente não encontrado.");
            }

            var allAppointments = await _context.Appointments
                .Where(a => a.PatientId == id)
                .Include(a => a.Dentist)
                    .ThenInclude(d => d.User)
                .OrderBy(a => a.Date)
                .ThenBy(a => a.Time)
                .ToListAsync();

            var viewModel = new ViewAppointmentsViewModel
            {
                PatientId = patient.Id,
                Patient = patient,
                PatientName = patient.User?.Name,
                DateOfBirth = patient.DateOfBirth,
                Age = CalculateAge(patient.DateOfBirth), 
                Appointment = allAppointments
            };

            return View(viewModel);

        }

        [Authorize(Roles = UserTypes.Dentist)]
        [Route("Paciente/Dentista/{id}")]
        [HttpGet]
        public async Task<IActionResult> SingleDentist(string id)
        {
            var authenticatedUserId = GetAuthenticatedUserId();
            var authenticatedUserRole = GetAuthenticatedUserRole();

            if (string.IsNullOrEmpty(authenticatedUserId) || string.IsNullOrEmpty(authenticatedUserRole))
            {
                return Unauthorized("Não foi possível obter o usuário autenticado.");
            }

            if (authenticatedUserRole == UserTypes.Dentist && authenticatedUserId != id)
            {
                return Forbid("Você não tem permissão para acessar as consultas deste dentista.");
            }
        
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id de Dentista Inválido.");
            }

            var dentist = await _context.Dentists
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dentist == null)
            {
                return NotFound("Dentista não encontrado.");
            }

            var appointmentsForDentist = await _context.Appointments
                .Where(a => a.DentistId == id)
                .Include(a => a.Patient)
                    .ThenInclude(p => p.User) 
                .OrderBy(a => a.Date)
                .ThenBy(a => a.Time)
                .ToListAsync();

            var appointmentViewModel = new List<ViewAppointmentsViewModel>();

            foreach (var appointment in appointmentsForDentist)
            {
                appointmentViewModel.Add(new ViewAppointmentsViewModel
                {
                    AppointmentId = appointment.Id,
                    Date = appointment.Date,
                    Time = appointment.Time,
                    DentistId = dentist.Id,
                    DentistName = dentist.User?.Name,
                    PatientName = appointment.Patient?.User?.Name,
                    PatientId = appointment.PatientId,
                    Age = CalculateAge(appointment.Patient?.DateOfBirth) 
                });
            }
            return View(appointmentViewModel);
        }

        private int CalculateAge(DateOnly? dateOfBirth)
        {
            if (!dateOfBirth.HasValue)
                return 0;

            var today = DateOnly.FromDateTime(DateTime.Now);
            int age = today.Year - dateOfBirth.Value.Year;
            if (today < dateOfBirth.Value.AddYears(age)) age--;
            return age;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string appointmentId, string? patientIdForRedirect)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Agendamento cancelado com sucesso!";

            if (!string.IsNullOrEmpty(patientIdForRedirect))
            {
                var patientExists = await _context.Patients.AnyAsync(p => p.Id == patientIdForRedirect);
                if (patientExists)
                {
                    return RedirectToAction(nameof(SinglePatient), new { id = patientIdForRedirect });
                }
            }
            return RedirectToAction(nameof(Index));
        }



        private string? GetAuthenticatedUserId()
        {
            return User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
        }

        private string? GetAuthenticatedUserRole()
        {
            return User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value;
        }
    }
}