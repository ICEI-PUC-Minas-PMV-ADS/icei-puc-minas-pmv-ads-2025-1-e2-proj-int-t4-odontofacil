using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoFacil.Models.Data;

[Table("Endereco")]
public partial class Address
{
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("cep")]
    public string Cep { get; set; } = null!;

    [Column("rua")]
    public string Street { get; set; } = null!;

    [Column("numero")]
    public string? Number { get; set; }

    [Column("complemento")]
    public string? Complement { get; set; }

    [Column("bairro")]
    public string Neighborhood { get; set; } = null!;

    [Column("cidade")]
    public string City { get; set; } = null!;

    [Column("estado")]
    public string State { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
