using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdontoFacil.Constants;
using OdontoFacil.Data;
using OdontoFacil.Models.Data;
using OdontoFacil.Models.Views;

namespace OdontoFacil.Controllers;

public partial class ExamRequestController : Controller
{
    private OdontoFacilDbContext _context;
    public ExamRequestController(OdontoFacilDbContext context)
    {
        _context = context;
    }

    [Route("/Solicitacoes")]
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var users = await _context.Users
                .Where(user => user.UserType == UserTypes.Patient)
                .OrderBy(user => user.Name)
                .ToListAsync();

        var types = await _context.ExamTypes.ToListAsync();
        
        ViewBag.Users = users;
        ViewBag.Types = types;

        return View(new CreateExamRequestViewModel());
    }

    [Route("/Solicitacoes")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateExamRequestViewModel formData)
    {
        {
            var userId = GetAuthenticatedUserId();

            if (ModelState.IsValid && userId != null) 
            {

                var examRequest = new ExamRequest
                {   
                    Id = Guid.NewGuid().ToString(),
                    PatientId = formData.PatientId,
                    Type = formData.TypeId,
                    RequestDate = DateOnly.FromDateTime(DateTime.Now),
                    DentistId = userId
                };
                _context.ExamRequests.Add(examRequest);

                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Create));
        }
    }

    private string? GetAuthenticatedUserId()
    {
        return User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
    }
    
}

