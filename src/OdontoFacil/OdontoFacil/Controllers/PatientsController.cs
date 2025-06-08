using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using OdontoFacil.Constants;
using OdontoFacil.Models.Views;
using OdontoFacil.Data;
using OdontoFacil.Models.Data;

namespace OdontoFacil.Controllers
{
    [Authorize(Roles = $"{UserTypes.Dentist},{UserTypes.Helper}")]
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

            return View("List", patientListViewModels); 
        }

        
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

        

        [HttpGet]
        [Route("Paciente/{patientId}/Editar")]
        public async Task<IActionResult> Edit(string patientId)
        {
            if (string.IsNullOrWhiteSpace(patientId))
            {
                return BadRequest("ID do paciente é obrigatório");
            }

            var patient = await GetPatient(patientId);

            if (patient == null)
            {
                return NotFound($"Paciente com ID {patientId} não encontrado");
            }

            var healthPlans = await _context.HealthPlans.ToListAsync();

            ViewBag.HealthPlans = healthPlans;

            var updateViewModel = new UpdatePatientViewModel(patient);
            return View(updateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Paciente/{patientId}/Editar")]
        public async Task<IActionResult> Update(string patientId, UpdatePatientViewModel model)
        {
            if (string.IsNullOrWhiteSpace(patientId) || model == null)
            {
                return BadRequest("Dados inválidos");
            }

            if (patientId != model.Id)
            {
                return BadRequest("ID do paciente não corresponde");
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            try
            {
                var success = await UpdatePatient(model.Id, model);

                if (!success)
                {
                    return NotFound($"Paciente com ID {model.Id} não encontrado");
                }

                return RedirectToAction(nameof(Edit), new { patientId = model.Id });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar paciente {model.Id}: {ex.Message}");

                ModelState.AddModelError("", "Ocorreu um erro interno. Tente novamente mais tarde.");
                return View("Edit", model);
            }
        }

        private async Task<Patient?> GetPatient(string patientId)
        {
            return await _context.Patients
                .Include(p => p.User)
                .Include(p => p.Address)
                .Include(p => p.HealthPlan)
                .FirstOrDefaultAsync(p => p.Id == patientId);
        }

        private async Task<bool> UpdatePatient(string patientId, UpdatePatientViewModel model)
        {
            var patient = await GetPatient(patientId);

            if (patient == null)
            {
                return false;
            }

            if (patient.User != null)
            {
                patient.User.Name = model.Name?.Trim();
                patient.User.Email = model.Email?.Trim().ToLowerInvariant();
                patient.User.CPF = model.CPF;
            }

            patient.PhoneNumber = model.PhoneNumber;
            patient.Sex = model.Sex;
            patient.DateOfBirth = model.DateOfBirth.HasValue
                ? DateOnly.FromDateTime(model.DateOfBirth.Value)
                : null;

            if (!string.IsNullOrEmpty(model.HealthPlanId))
            {
                var healthPlan = await _context.HealthPlans.FirstOrDefaultAsync(h => h.Id == model.HealthPlanId);
                patient.HealthPlan = healthPlan;
                patient.PlanId = healthPlan?.Id;
            }
            else
            {
                patient.HealthPlan = null;
                patient.PlanId = null;
            }

            bool hasAddressData = !string.IsNullOrWhiteSpace(model.CEP) ||
                                 !string.IsNullOrWhiteSpace(model.Street) ||
                                 !string.IsNullOrWhiteSpace(model.City);

            if (hasAddressData)
            {
                if (patient.Address == null)
                {
                    var newAddress = new Address
                    {
                        Id = Guid.NewGuid().ToString(),
                        Cep = model.CEP.Replace("-", "").Replace(".", "").Trim(),
                        Street = model.Street?.Trim(),
                        Number = model.Number?.Trim(),
                        Complement = model.Complement?.Trim(),
                        Neighborhood = model.Neighborhood?.Trim(),
                        City = model.City?.Trim(),
                        State = model.State?.Trim()
                    };
                    _context.Addresses.Add(newAddress);
                    patient.Address = newAddress;
                    patient.AddressId = newAddress.Id;
                }
                else if (patient.Address != null)
                {
                    patient.Address.Cep = model.CEP.Replace("-", "").Replace(".", "").Trim();
                    patient.Address.Street = model.Street?.Trim();
                    patient.Address.Number = model.Number?.Trim();
                    patient.Address.Complement = model.Complement?.Trim();
                    patient.Address.Neighborhood = model.Neighborhood?.Trim();
                    patient.Address.City = model.City?.Trim();
                    patient.Address.State = model.State?.Trim();
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        private int CalculateAge(DateOnly? dateOfBirth)
        {
            if (!dateOfBirth.HasValue)
                return 0;

            var today = DateOnly.FromDateTime(DateTime.Now);
            int age = today.Year - dateOfBirth.Value.Year;

            // Ajustar se ainda não fez aniversário este ano
            if (today < dateOfBirth.Value.AddYears(age))
            {
                age--;
            }

            return age;
        }

    }
}