using System.ComponentModel.DataAnnotations;

namespace OdontoFacil.Models.Views;

public class ScheduleAppointmentViewModel
{
    [Display(Name = "Dentista")]
    [Required(ErrorMessage = "O campo dentista é obrigatório.")]
    public string DentistId { get; set; } = null!;

    [Display(Name = "Datas disponíveis")]
    [Required(ErrorMessage = "O campo data é obrigatório.")]
    public string Date { get; set; } = null!;

    [Display(Name = "Horários disponíveis")]
    [Required(ErrorMessage = "O campo hora é obrigatório.")]
    public string Time { get; set; } = null!;

    [Display(Name = "Paciente")]
    [Required(ErrorMessage = "O campo paciente é obrigatório.")]
    public string UserId { get; set; } = null!;
}