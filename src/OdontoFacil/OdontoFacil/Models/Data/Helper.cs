using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoFacil.Models.Data;

[Table("Auxiliar")]
public partial class Helper
{
    [Key]
    [ForeignKey(nameof(User))]
    [Column("id")]
    public string Id { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
