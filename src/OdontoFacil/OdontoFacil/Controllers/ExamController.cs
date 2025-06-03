using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoFacil.Constants;
using OdontoFacil.Data;
using OdontoFacil.Models.Data;
using OdontoFacil.Models.Views;

namespace OdontoFacil.Controllers;

[Authorize]
public partial class ExamController : Controller
{

  private OdontoFacilDbContext _context;

  public ExamController(OdontoFacilDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  [Route("/Exames")]
  public async Task<IActionResult> Index(string? userId)
  {
    var currentUserId = GetAuthenticatedUserId();
    var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == currentUserId);

    if (currentUser == null)
      return Unauthorized();

    IQueryable<ExamRequest> query = _context.ExamRequests
        .Include(e => e.Dentist.User)
        .Include(e => e.Patient.User)
        .Include(e => e.TypeNavigation);

    if (currentUser.UserType == UserTypes.Patient)
    {
      query = query.Where(e => e.PatientId == currentUser.Id);
    }
    else if ((currentUser.UserType == UserTypes.Dentist || currentUser.UserType == UserTypes.Helper) && !string.IsNullOrEmpty(userId))
    {
      query = query.Where(e => e.PatientId == userId);
    }

    var exams = await query.ToListAsync();

    if (currentUser.UserType == UserTypes.Dentist || currentUser.UserType == UserTypes.Helper)
    {
      var pacientes = await _context.Users
          .Where(u => u.UserType == UserTypes.Patient)
          .Select(u => new { u.Id, u.Name, u.CPF })
          .ToListAsync();

      ViewBag.Users = pacientes;
    }

    var model = new ExamViewModel(exams)
    {
      UserId = userId
    };

    return View(model);
  }

  private string? GetAuthenticatedUserId()
  {
    return User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
  }
}