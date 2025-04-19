using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoFacil.Models.Data;

[Table("Tipo_Exame")]
public partial class ExamType
{
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("descricao")]
    public string Description { get; set; } = null!;

    public virtual ICollection<ExamRequest> ExamRequests { get; set; } = new List<ExamRequest>();
}
