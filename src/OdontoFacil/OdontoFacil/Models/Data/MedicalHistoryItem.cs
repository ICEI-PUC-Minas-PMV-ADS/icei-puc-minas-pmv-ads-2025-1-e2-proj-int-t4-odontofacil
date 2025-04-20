using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoFacil.Models.Data;

[Table(name: "Antecedente")]
public partial class MedicalHistoryItem
{
    [Column(name: "id")]
    public string Id { get; set; } = null!;

    [Column(name: "descricao")]
    public string Description { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
