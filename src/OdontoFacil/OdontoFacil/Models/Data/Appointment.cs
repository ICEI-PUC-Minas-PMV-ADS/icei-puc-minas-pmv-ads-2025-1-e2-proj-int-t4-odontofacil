using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoFacil.Models.Data;

[Table(name: "Atendimento")]
public partial class Appointment
{
    [Column(name: "id")]
    public string Id { get; set; } = null!;

    [Column(name: "id_dentista")]
    [ForeignKey(nameof(Dentist))]
    public string DentistId { get; set; } = null!;

    [Column(name: "id_paciente")]
    [ForeignKey(nameof(Patient))]
    public string PatientId { get; set; } = null!;

    [Column(name: "data")]
    public DateOnly Date { get; set; }
    
    [Column(name: "hora")]
    public TimeOnly Time { get; set; }

    public virtual Dentist Dentist { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
