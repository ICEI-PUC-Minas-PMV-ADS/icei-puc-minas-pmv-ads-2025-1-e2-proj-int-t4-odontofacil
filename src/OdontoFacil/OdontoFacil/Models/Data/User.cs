using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoFacil.Models.Data;

[Table(name: "Usuario")]
public partial class User
{
    [Key]
    [Column(name: "id")]
    public string Id { get; set; } = null!;

    [Column(name: "nome")]
    public string Name { get; set; } = null!;

    [Column(name: "email")]
    public string Email { get; set; } = null!;

    [Column(name: "cpf")]
    public string CPF { get; set; } = null!;

    [Column(name: "senha")]
    public string Password { get; set; } = null!;

    [Column(name: "tipo")]
    public string UserType { get; set; } = null!;

    [Column(name: "telefone")]
    public string PhoneNumber { get; set; } = null!;

    public virtual Helper? Helper { get; set; }

    public virtual Dentist? Dentist { get; set; }

    public virtual Patient? Patient { get; set; }
}
