using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using OdontoFacil.Models.Data;

namespace OdontoFacil.Models.Views;

public class ViewAppointmentsViewModel

{
    public Patient? Patient { get; set; }
    public List<Note> Note { get; set; }
    public Dentist Dentist { get; set; }
    public List<Appointment> Appointment { get; set; }
    public User User { get; set; }

    [Display(Name = "Nome completo")]
    [Required(ErrorMessage = "O campo nome é obrigatório.")]
    public string? Name { get; set; } = null!;

    [Display(Name = "Data de nascimento")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "O campo data de nascimento é obrigatório.")]
    public DateOnly? DateOfBirth { get; set; } = null!;

    [Display(Name = "Idade")]
    public int Age { get; set; }

    [Display(Name = "data")]
    public DateOnly Date { get; set; }

    [Display(Name = "hora")]
    public TimeOnly Hour { get; set; }

    [Display(Name = "Anotação")]
    public string PatientNote { get; set; } = null!;

    [Display(Name = "Conteúdo")]
    public string ContentNote { get; set; } = null!;

    [Display(Name = "Dentista ID")]
    public string DentistId { get; set; } = null!;

    [Display(Name = "Paciente ID")]
    public string PatientId { get; set; } = null!;

    public string? PatientName { get; set; } = null!;

    public string? DentistName { get; set; } = null!;

    public string? AppointmentId { get; set; } = null!;

    public string? Id { get; set; } = null!;

    
}
