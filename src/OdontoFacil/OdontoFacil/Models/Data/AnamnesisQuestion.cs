using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoFacil.Models.Data;

[Table(name: "Pergunta_Anamnese")]
public partial class AnamnesisQuestion
{
    [Key]
    [Column(name: "id")]
    public string Id { get; set; } = null!;

    [Column(name: "descricao")]
    public string Description { get; set; } = null!;
}
