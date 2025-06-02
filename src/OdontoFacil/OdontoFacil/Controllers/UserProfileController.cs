using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OdontoFacil.Constants;
using OdontoFacil.Data;
using OdontoFacil.Models.Data;
using OdontoFacil.Models.Views;

namespace OdontoFacil.Controllers;

[Authorize(Roles = UserTypes.Patient)]
public partial class UserProfileControlle(OdontoFacilDbContext context) : Controller
{

    private readonly OdontoFacilDbContext _context = context;

    [Route("/Perfil")]
    public IActionResult Index()
    {
        var userId = User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
        var user = _context.Users
                    .Include(user => user.Patient)
                    .FirstOrDefault(u => u.Id == userId);

        if (user == null || user.Patient == null)
        {
            return NotFound();
        }

        var profileViewModel = new ProfileViewModel
        {
            Id = user.Id,
            Name = user.Name,
            CPF = user.CPF,
            Email = user.Email,
            Phone = user.PhoneNumber,
            DateOfBirth = user.Patient.DateOfBirth,
            Password = user.Password
        };

        return View(profileViewModel);
    }

    [HttpPost]
    [Route("/Perfil")]
    public IActionResult Edit(ProfileViewModel formData)
    {
        var userId = GetAuthenticatedUserId();

        if (ModelState.IsValid && userId != null)
        {

            UpdateUser(userId, formData);
            UpdatePatient(userId, formData);
            _context.SaveChanges();
        }

        return RedirectToAction(nameof(Index));
    }

    private void UpdateUser(string userId, ProfileViewModel formData)
    {
        var user = new User { Id = userId };
        _context.Users.Attach(user);

        user.Email = formData.Email;

        if (formData.Password != null)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(formData.Password.Trim());
        }
    }

    private void UpdatePatient(string userId, ProfileViewModel formData)
    {
        var patient = new Patient { Id = userId };
        _context.Patients.Attach(patient);

        patient.PhoneNumber = OnlyDigits().Replace(formData.Phone, "");
        patient.DateOfBirth = formData.DateOfBirth;
    }


    private string? GetAuthenticatedUserId()
    {
        return User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"\D")]
    private static partial System.Text.RegularExpressions.Regex OnlyDigits();
}