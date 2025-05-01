
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using OdontoFacil.Constants;
using OdontoFacil.Data;
using OdontoFacil.Models.Data;
using OdontoFacil.Models.Views;

namespace OdontoFacil.Controllers;

public partial class RegistrationController : Controller
{
    private readonly OdontoFacilDbContext _context;

    public RegistrationController(OdontoFacilDbContext context)
    {
        _context = context;
    }

    [Route("Cadastro")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("Cadastro")]
    [HttpPost]
    public async Task<IActionResult> Index(RegistrationViewModel formData)
    {
        if (!ModelState.IsValid)
        {
            return View(formData);
        }

        if (UserExists(formData.CPF, formData.Email))
        {
            ViewBag.ErrorMessage = "Já existe um usuário cadastrado com esse CPF ou e-mail.";
            return View(formData);
        }

        var userId = Guid.NewGuid().ToString();
        await _context.AddAsync(MapViewToUserModel(userId, formData));
        await _context.AddAsync(new Patient { Id = userId });
        await _context.SaveChangesAsync();
        return Redirect("/Login");
    }

    private bool UserExists(string cpf, string email)
    {
        var cleanCpf = NumberOnly().Replace(cpf, "");
        return _context.Users.Any(e => e.CPF == cleanCpf || e.Email == email);
    }

    private static User MapViewToUserModel(string id, RegistrationViewModel formData)
    {
        return new User
        {
            Id = id,
            Name = formData.Name.Trim(),
            Email = formData.Email.Trim().ToLower(),
            CPF = NumberOnly().Replace(formData.CPF, ""),
            UserType = UserTypes.Patient,
            Password = BCrypt.Net.BCrypt.HashPassword(formData.Password)
        };
    }

    [GeneratedRegex(@"\D")]
    private static partial Regex NumberOnly();
}
