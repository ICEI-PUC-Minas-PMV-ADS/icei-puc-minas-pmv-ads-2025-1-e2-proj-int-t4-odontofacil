using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoFacil.Data;
using OdontoFacil.Models.Views;

namespace OdontoFacil.Controllers;

public partial class DentistController : Controller
{

    private readonly OdontoFacilDbContext _context;

    public DentistController(OdontoFacilDbContext context)
    {
    _context = context;
  }

  [Route("/Dentistas")]
  public async Task<IActionResult> Index()
  {
    var dentists = await _context.Dentists
        .Include(p => p.User)
        .ToListAsync();

    return View(dentists);
  }

  [HttpGet]
  [Route("/Dentistas/Editar/{id}")]
  public async Task<IActionResult> Edit(string id)
  {
    var dentist = await _context.Dentists
        .Include(d => d.User)
        .FirstOrDefaultAsync(d => d.Id == id);

    if (dentist == null)
    {
      return NotFound();
    }

    var viewModel = new UpdateDentistViewModel
    {
      Name = dentist.User.Name,
      CPF = dentist.User.CPF,
      Email = dentist.User.Email,
      CRO = dentist.CRO
    };

    ViewData["DentistId"] = dentist.Id;


    return View(viewModel);
  }

  [HttpPost]
  [Route("/Dentistas/Editar")]
  public async Task<IActionResult> UpdateDentist(string id, UpdateDentistViewModel formData)
  {
    var dentist = await _context.Dentists
        .Include(d => d.User)
        .FirstOrDefaultAsync(d => d.Id == id);

    if (dentist == null)
    {
      return NotFound("Erro ao procurar o dentista.");
    }

    if (!string.IsNullOrEmpty(formData.Name)) dentist.User.Name = formData.Name;
    if (!string.IsNullOrEmpty(formData.CPF)) dentist.User.CPF = formData.CPF;
    if (!string.IsNullOrEmpty(formData.Email)) dentist.User.Email = formData.Email;
    if (!string.IsNullOrEmpty(formData.CRO)) dentist.CRO = formData.CRO;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
      return BadRequest("Ocorreu um erro ao atualizar o dentista: " + ex.Message);
    }

    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  [Route("/Dentistas/Delete/{id}")]
  public async Task<IActionResult> DeleteDentist(string id)
  {
    var dentist = await _context.Dentists
        .Include(d => d.User)
        .FirstOrDefaultAsync(d => d.Id == id);

    if (dentist == null)
    {
      return NotFound("Dentista não encontrado.");
    }

    try
    {
      _context.Users.Remove(dentist.User);
      _context.Dentists.Remove(dentist);
      await _context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
      return BadRequest($"Erro ao deletar o dentista: {ex.Message}");
    }

    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  [Route("/Dentistas/Criar")]
  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  [Route("/Dentistas/Criar")]
  public async Task<IActionResult> CreateDentist(CreateDentistViewModel formData)
  {
    if (!ModelState.IsValid)
    {
      return View(formData);
    }

    var dentist = formData.ToEntity();

    try
    {
      _context.Dentists.Add(dentist);
      await _context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
      return StatusCode(500, "Ocorreu um erro interno ao criar o dentista: " + ex.Message);
    }

    return RedirectToAction(nameof(Index));
  }

}