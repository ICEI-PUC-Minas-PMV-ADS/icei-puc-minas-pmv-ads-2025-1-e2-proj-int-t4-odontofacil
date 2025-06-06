using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OdontoFacil.Data;
using OdontoFacil.Models.Data;
using OdontoFacil.Models.Views;
using Microsoft.AspNetCore.Authentication.Cookies;
using OdontoFacil.Constants;
using Microsoft.EntityFrameworkCore;

namespace OdontoFacil.Controllers;

public class LoginController : Controller
{

    private OdontoFacilDbContext _context;

    public LoginController(OdontoFacilDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> IndexAsync(LoginViewModel formData)
    {
        if (!ModelState.IsValid)
        {
            return View(formData);
        }

        var user = await GetUser(formData.Email.Trim().ToLower());

        if (user == null || !BCrypt.Net.BCrypt.Verify(formData.Password, user.Password))
        {
            ViewBag.ErrorMessage = "E-mail ou senha inválidos.";
            return View(formData);
        }

        await PerformSignIn(user);

        var redirectPath = user.UserType == UserTypes.Patient ? "/Perfil" : "/Pacientes";

        return Redirect(redirectPath);

    }

    private async Task<User?> GetUser(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }

    private async Task PerformSignIn(User user)
    {
        var claims = new List<Claim>
        {
            new("UserId", user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.UserType),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }
}