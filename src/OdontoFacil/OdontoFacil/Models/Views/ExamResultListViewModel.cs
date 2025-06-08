using System.ComponentModel.DataAnnotations;

namespace OdontoFacil.Models.Views;

public class ExamResultListViewModel
{
    public string Id { get; set; } = null!;

    [Display(Name = "Paciente")]
    public string PatientName { get; set; } = null!;

    [Display(Name = "CPF do Paciente")]
    public string PatientCPF { get; set; } = null!;

    [Display(Name = "Tipo de Exame")]
    public string ExamTypeDescription { get; set; } = null!;

    [Display(Name = "Data da Solicitação")]
    [DataType(DataType.Date)]
    public DateOnly RequestDate { get; set; }

    [Display(Name = "Data do Resultado")]
    [DataType(DataType.Date)]
    public DateOnly ResultDate { get; set; }

    [Display(Name = "Laboratório")]
    public string Lab { get; set; } = null!;

   
    public string? ResultFilePath { get; set; }
}
