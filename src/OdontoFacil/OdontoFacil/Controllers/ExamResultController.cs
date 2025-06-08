using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OdontoFacil.Constants;
using OdontoFacil.Data;
using OdontoFacil.Models.Data;
using OdontoFacil.Models.Views;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.StaticFiles;

namespace OdontoFacil.Controllers;

[Authorize(Roles = $"{UserTypes.Dentist},{UserTypes.Helper},{UserTypes.Patient}")]
[Route("[controller]")]
public class ExamResultController : Controller
{
    private readonly OdontoFacilDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ExamResultController(OdontoFacilDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    
    [HttpGet]
    [Route("AnexarResultado")]
    public async Task<IActionResult> Attach(string? patientId = null)
    {
        var viewModel = new AttachExamResultViewModel();
        var loggedUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ??
                           User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
        var loggedUserType = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        viewModel.LoggedUserType = loggedUserType;

        if (loggedUserType == UserTypes.Patient)
        {
            viewModel.PatientId = loggedUserId!;
            viewModel.AvailableExamRequests = await _context.ExamRequests
                .Include(er => er.TypeNavigation)
                .Where(er => er.PatientId == loggedUserId)
                .Select(er => new SelectListItem
                {
                    Value = er.Id,
                    Text = $"{er.TypeNavigation.Description} - {er.RequestDate.ToShortDateString()}"
                })
                .ToListAsync();
        }
        else
        {
            viewModel.AvailablePatients = await _context.Patients
                .Include(p => p.User)
                .Select(p => new SelectListItem { Value = p.Id, Text = p.User.Name })
                .OrderBy(sli => sli.Text)
                .ToListAsync();

            if (!string.IsNullOrEmpty(patientId) && viewModel.AvailablePatients.Any(p => p.Value == patientId))
            {
                viewModel.PatientId = patientId;
                viewModel.AvailableExamRequests = await _context.ExamRequests
                    .Include(er => er.TypeNavigation)
                    .Where(er => er.PatientId == patientId)
                    .Select(er => new SelectListItem
                    {
                        Value = er.Id,
                        Text = $"{er.TypeNavigation.Description} - {er.RequestDate.ToShortDateString()}"
                    })
                    .ToListAsync();
            }
            else
            {
                viewModel.AvailableExamRequests = [];
            }
        }

        return View(viewModel);
    }

    [HttpPost]
    [Route("AnexarResultado")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Attach(AttachExamResultViewModel model)
    {
        var loggedUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ??
                           User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
        var loggedUserType = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        if (loggedUserType == UserTypes.Patient)
        {
            model.PatientId = loggedUserId!;
            model.AvailableExamRequests = await _context.ExamRequests
                .Include(er => er.TypeNavigation)
                .Where(er => er.PatientId == loggedUserId)
                .Select(er => new SelectListItem { Value = er.Id, Text = $"{er.TypeNavigation.Description} - {er.RequestDate.ToShortDateString()}" })
                .ToListAsync();
        }
        else
        {
            model.AvailablePatients = await _context.Patients
                .Include(p => p.User)
                .Select(p => new SelectListItem { Value = p.Id, Text = p.User.Name })
                .OrderBy(sli => sli.Text)
                .ToListAsync();

            if (!string.IsNullOrEmpty(model.PatientId))
            {
                model.AvailableExamRequests = await _context.ExamRequests
                   .Include(er => er.TypeNavigation)
                   .Where(er => er.PatientId == model.PatientId)
                   .Select(er => new SelectListItem { Value = er.Id, Text = $"{er.TypeNavigation.Description} - {er.RequestDate.ToShortDateString()}" })
                   .ToListAsync();
            }
            else
            {
                model.AvailableExamRequests = [];
            }
        }
        model.LoggedUserType = loggedUserType;

        if (!ModelState.IsValid)
        {
            ViewBag.ErrorMessage = "Por favor, corrija os erros no formulário.";
            return View(model);
        }

        string? filePath = null;
        if (model.ResultFile != null && model.ResultFile.Length > 0)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "examresults");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ResultFile.FileName);
            filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.ResultFile.CopyToAsync(fileStream);
            }

            filePath = Path.Combine("~/", "uploads", "examresults", uniqueFileName).Replace("\\", "/");
        }
        else
        {
            ModelState.AddModelError("ResultFile", "O arquivo do resultado é obrigatório.");
            ViewBag.ErrorMessage = "Por favor, selecione um arquivo de resultado."; 
            return View(model);
        }

        var examResult = new ExamResult
        {
            ExamRequestId = model.ExamRequestId,
            Date = model.ResultDate,
            Lab = model.Lab,
            ResultFilePath = filePath
        };

        try
        {
            await _context.ExamResults.AddAsync(examResult);
            await _context.SaveChangesAsync();

            ViewBag.SuccessMessage = "Resultado de exame anexado com sucesso!";
            return View(new AttachExamResultViewModel
            {
                LoggedUserType = loggedUserType,
                PatientId = (loggedUserType == UserTypes.Patient) ? loggedUserId! : null!,
                AvailablePatients = model.AvailablePatients,
                AvailableExamRequests = (loggedUserType == UserTypes.Patient || !string.IsNullOrEmpty(model.PatientId)) ? await _context.ExamRequests
                    .Include(er => er.TypeNavigation)
                    .Where(er => er.PatientId == ((loggedUserType == UserTypes.Patient) ? loggedUserId! : model.PatientId))
                    .Select(er => new SelectListItem { Value = er.Id, Text = $"{er.TypeNavigation.Description} - {er.RequestDate.ToShortDateString()}" })
                    .ToListAsync() : []
            });
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Ocorreu um erro ao anexar o resultado: {ex.Message}");
            ViewBag.ErrorMessage = "Ocorreu um erro ao anexar o resultado.";
            return View(model);
        }
    }

    
    [HttpGet]
    [Route("ListarResultados")]
    public async Task<IActionResult> ListResults()
    {
        var loggedUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ??
                           User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
        var loggedUserType = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        IQueryable<ExamResult> query = _context.ExamResults
            .Include(er => er.ExamRequest)
                .ThenInclude(req => req.TypeNavigation)
            .Include(er => er.ExamRequest)
                .ThenInclude(req => req.Patient)
                    .ThenInclude(p => p.User);

        if (loggedUserType == UserTypes.Patient)
        {
            query = query.Where(er => er.ExamRequest.PatientId == loggedUserId);
        }

        var examResults = await query
            .OrderByDescending(er => er.Date)
            .ToListAsync();

        var viewModelList = examResults.Select(er => new ExamResultListViewModel
        {
            Id = er.Id,
            PatientName = er.ExamRequest.Patient.User.Name,
            PatientCPF = er.ExamRequest.Patient.User.CPF,
            ExamTypeDescription = er.ExamRequest.TypeNavigation.Description,
            RequestDate = er.ExamRequest.RequestDate,
            ResultDate = er.Date,
            Lab = er.Lab,
            ResultFilePath = er.ResultFilePath
        }).ToList();

        return View(viewModelList);
    }

    
    [HttpGet]
    [Route("VisualizarOuBaixar/{id}")] 
    public async Task<IActionResult> DownloadResult(string id)
    {
        var loggedUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ??
                           User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
        var loggedUserType = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        var examResult = await _context.ExamResults
            .Include(er => er.ExamRequest)
                .ThenInclude(req => req.Patient)
            .FirstOrDefaultAsync(er => er.Id == id);

        if (examResult == null || string.IsNullOrEmpty(examResult.ResultFilePath))
        {
            return NotFound("Resultado de exame ou arquivo não encontrado.");
        }

        
        bool isAuthorized = false;
        if (loggedUserType == UserTypes.Patient)
        {
            if (examResult.ExamRequest.Patient.Id == loggedUserId)
            {
                isAuthorized = true;
            }
        }
        else if (loggedUserType == UserTypes.Dentist || loggedUserType == UserTypes.Helper)
        {
            isAuthorized = true;
        }

        if (!isAuthorized)
        {
            return Forbid(); 
        }

        var filePath = examResult.ResultFilePath!.Replace("~/", "");
        var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);

        if (!System.IO.File.Exists(fullPath))
        {
            return NotFound("Arquivo não encontrado no servidor.");
        }

        var fileBytes = await System.IO.File.ReadAllBytesAsync(fullPath);
        var fileName = Path.GetFileName(fullPath);

        string contentType = "application/octet-stream";
        var provider = new FileExtensionContentTypeProvider();
        if (provider.TryGetContentType(fileName, out var fileContentType))
        {
            contentType = fileContentType;
        }

        var contentDisposition = "attachment";
        if (contentType.StartsWith("image/") || contentType == "application/pdf")
        {
            contentDisposition = "inline"; 
        }
       
        Response.Headers.Append("Content-Disposition", $"{contentDisposition}; filename=\"{fileName}\"");
        return File(fileBytes, contentType); 
    }

    [HttpGet]
    [Route("GetExamRequestsByPatientId")]
    public async Task<IActionResult> GetExamRequestsByPatientId(string patientId)
    {
        var examRequests = await _context.ExamRequests
            .Include(er => er.TypeNavigation)
            .Where(er => er.PatientId == patientId)
            .Select(er => new
            {
                id = er.Id,
                text = $"{er.TypeNavigation.Description} - {er.RequestDate.ToShortDateString()}",
                examTypeDescription = er.TypeNavigation.Description
            })
            .ToListAsync();

        return Json(examRequests);
    }
}