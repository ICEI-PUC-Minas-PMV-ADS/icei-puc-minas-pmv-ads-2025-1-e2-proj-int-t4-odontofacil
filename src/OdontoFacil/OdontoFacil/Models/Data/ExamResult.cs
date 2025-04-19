using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoFacil.Models.Data;

[Table("Resultado_Exame")]
public partial class ExamResult
{
    [Column("id")]
    public string Id { get; set; } = null!;

    [ForeignKey(nameof(ExamRequest))]
    [Column("id_pedido_exame")]
    public string ExamRequestId { get; set; } = null!;

    [Column("data")]
    public DateOnly Date { get; set; }

    [Column("laboratorio")]
    public string Lab { get; set; } = null!;

    public virtual ExamRequest ExamRequest { get; set; } = null!;
}
