using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoFacil.Models.Data;

[Table(name: "Dentista")]
public partial class Dentist
{

    [Key]
    [ForeignKey(nameof(User))]
    [Column(name: "id")]
    public string Id { get; set; } = null!;

    [Column(name: "cro")]
    public string CRO { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<ExamRequest> ExamRequests { get; set; } = new List<ExamRequest>();

    public virtual ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
}
