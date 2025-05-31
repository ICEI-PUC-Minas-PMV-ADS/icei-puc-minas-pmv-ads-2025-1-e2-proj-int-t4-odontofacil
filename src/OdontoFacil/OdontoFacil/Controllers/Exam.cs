using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoFacil.Data;
using OdontoFacil.Models.Views;

namespace OdontoFacil.Controllers;

public partial class ExamController : Controller
{

  private OdontoFacilDbContext _context;

  public ExamController(OdontoFacilDbContext context)
  {
    _context = context;
  }

  [Route("/Exames")]
  public async Task<IActionResult> Index()
  {
    var exams = await _context.ExamRequests
      .Include(e => e.Dentist.User)
      .Include(e => e.Patient.User)
      .Include(e => e.TypeNavigation)
      .ToListAsync();

    var examsViews = exams.Select(e => new ExamViewModel(e)).ToList();

    return View(examsViews);
  }
}