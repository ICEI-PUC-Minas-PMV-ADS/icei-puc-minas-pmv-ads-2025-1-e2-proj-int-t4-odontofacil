using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering; // Para SelectListItem
using System; // Para DateOnly

namespace OdontoFacil.Models.Views;

public class AttachExamResultViewModel
{

    [Required(ErrorMessage = "O paciente é obrigatório.")]
    [Display(Name = "Paciente")]
    public string PatientId { get; set; } = null!;


    [Required(ErrorMessage = "A solicitação de exame é obrigatória.")]
    [Display(Name = "Solicitação de Exame")]
    public string ExamRequestId { get; set; } = null!;


    [Display(Name = "Tipo de Exame")]
    public string? ExamTypeDescription { get; set; }


    [Required(ErrorMessage = "A data do resultado é obrigatória.")]
    [Display(Name = "Data do Resultado")]
    [DataType(DataType.Date)]
    public DateOnly ResultDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);


    [Required(ErrorMessage = "O laboratório é obrigatório.")]
    [Display(Name = "Laboratório")]
    public string Lab { get; set; } = null!;

    [Required(ErrorMessage = "O arquivo do resultado é obrigatório.")] 
    [Display(Name = "Arquivo do Resultado")]
    public IFormFile ResultFile { get; set; } = null!; 

    public List<SelectListItem>? AvailablePatients { get; set; }
    public List<SelectListItem>? AvailableExamRequests { get; set; }


    public string? LoggedUserType { get; set; }
}
