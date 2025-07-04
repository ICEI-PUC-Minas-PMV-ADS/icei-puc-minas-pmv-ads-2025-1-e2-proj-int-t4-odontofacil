using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdontoFacil.Models.Data;

namespace OdontoFacil.Models.Views;

public class CreateExamRequestViewModel
{
    [Display(Name = "Paciente")]
    [Required(ErrorMessage = "O paciente é obrigatório.")]
    public string PatientId { get; set; } = null!;
    
    [Required(ErrorMessage = "O tipo de exame é obrigatório.")]
    [Display(Name = "Tipo de Exame")]
    public string? TypeId { get; set; }
}