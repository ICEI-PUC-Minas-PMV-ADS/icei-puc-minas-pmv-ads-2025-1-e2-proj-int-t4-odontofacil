using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoFacil.Models.Data;

[Table(name: "Anotacoes")]
public partial class Note
{
    [Key]
    [Column(name: "id")]
   
    public string Id { get; set; } = null!;

    [Column(name: "nome")]
    public string PatientNote { get; set; } = null!;

    [Column(name: "conteudo")]
    public string ContentNote { get; set; } = null!;

    [Column(name: "data_criacao")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column(name: "id_paciente")]
    [ForeignKey(nameof(Patient))]
    public required string PatientId { get; set; }

    [Column(name: "id_dentista")]
    [ForeignKey(nameof(Dentist))]
    public required string DentistId { get; set; }

    public required Patient Patient { get; set; }

    public required Dentist Dentist { get; set; }

}
