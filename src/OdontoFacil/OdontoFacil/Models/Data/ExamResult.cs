using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 
using System; 

namespace OdontoFacil.Models.Data;

[Table("Resultado_Exame")]
public partial class ExamResult
{
    [Column("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [ForeignKey(nameof(ExamRequest))]
    [Column("id_pedido_exame")]
    public string ExamRequestId { get; set; } = null!;

    [Column("data")]
    public DateOnly Date { get; set; }

    [Column("laboratorio")]
    public string Lab { get; set; } = null!;

    [Column("caminho_arquivo_resultado")]
    public string? ResultFilePath { get; set; }

    public virtual ExamRequest ExamRequest { get; set; } = null!;
}
