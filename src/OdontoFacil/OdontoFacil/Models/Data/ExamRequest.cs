using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 
using System; 
namespace OdontoFacil.Models.Data;

[Table("Pedido_Exame")] 
public partial class ExamRequest
{
    [Column("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString(); 

    [Column("tipo")]
    [ForeignKey(nameof(TypeNavigation))]
    public string Type { get; set; } = null!; 

    [Column("id_paciente")]
    [ForeignKey(nameof(Patient))]
    public string PatientId { get; set; } = null!;

    [Column("id_dentista")]
    [ForeignKey(nameof(Dentist))]
    public string DentistId { get; set; } = null!;

    [Column("data_solicitacao")]
    public DateOnly RequestDate { get; set; } 

    public virtual Dentist Dentist { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual ICollection<ExamResult> Results { get; set; } = new List<ExamResult>();

    public virtual ExamType TypeNavigation { get; set; } = null!; 
}
