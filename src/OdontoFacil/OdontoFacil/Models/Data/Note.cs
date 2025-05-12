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
    public string PatientId { get; set; }

    [Column(name: "id_dentista")]
    [ForeignKey(nameof(Dentist))]
    public string DentistId { get; set; }

    public Patient Patient { get; set; }

    public Dentist Dentist { get; set; }

}
