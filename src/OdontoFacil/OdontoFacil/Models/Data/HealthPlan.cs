using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoFacil.Models.Data;

[Table("Convenio")]
public partial class HealthPlan
{
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("nome")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
