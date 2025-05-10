using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoFacil.Models.Data;

[Table("Paciente")]
public partial class Patient
{
    [Key]
    [Column("id")]
    [ForeignKey(nameof(User))]
    public string Id { get; set; } = null!;

    [ForeignKey(nameof(HealthPlan))]
    [Column("id_convenio")]
    public string? PlanId { get; set; } = null!;

    [Column("data_nascimento")]
    public DateOnly? DateOfBirth { get; set; }

    [Column("telefone")]
    public string? PhoneNumber { get; set; } = null!;

    [ForeignKey(nameof(Address))]
    [Column("id_endereco")]
    public string? AddressId { get; set; } = null!;

    [Column("sexo")]
    public string? Sex { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual HealthPlan? HealthPlan { get; set; } = null!;

    public virtual Address? Address { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<ExamRequest> ExamRequests { get; set; } = new List<ExamRequest>();

    public virtual ICollection<MedicalHistoryItem> MedicalHistory { get; set; } = new List<MedicalHistoryItem>();
}
