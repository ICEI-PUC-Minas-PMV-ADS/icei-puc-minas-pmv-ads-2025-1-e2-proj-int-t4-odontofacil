using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoFacil.Models.Data;

[Table("Especialidade")]
public partial class Specialty
{

    [Column("id")]
    public string Id { get; set; } = null!;

    [Column(name: "nome")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Dentist> Dentists { get; set; } = new List<Dentist>();
}
