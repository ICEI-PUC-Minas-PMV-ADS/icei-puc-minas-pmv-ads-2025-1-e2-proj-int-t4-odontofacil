using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OdontoFacil.Models.Data;

[PrimaryKey(nameof(QuestionId), nameof(PatientId))]
[Table(name: "Resposta_Anamnese")]
public partial class AnamnesisAnswer
{
    [Column(name: "id_pergunta")]
    [ForeignKey(nameof(Dentist))]
    public string QuestionId { get; set; } = null!;

    [Column(name: "id_paciente")]
    [ForeignKey(nameof(Patient))]
    public string PatientId { get; set; } = null!;

    [Column(name: "resposta")]
    public bool Answer {get; set;} = false;
    
    [Column(name: "resposta_textual")]
    public string TextAnswer {get; set;} = null!;

    public virtual AnamnesisQuestion Question { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
