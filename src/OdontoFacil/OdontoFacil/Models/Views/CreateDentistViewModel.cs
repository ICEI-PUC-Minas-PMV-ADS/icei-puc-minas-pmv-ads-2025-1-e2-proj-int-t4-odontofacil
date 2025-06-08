using System.ComponentModel.DataAnnotations;
using OdontoFacil.Models.Data;
using OdontoFacil.Constants;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace OdontoFacil.Models.Views;

public partial class CreateDentistViewModel
{

  [Display(Name = "Nome")]
  [Required(ErrorMessage = "O campo nome é obrigatório.")]
  [RegularExpression(@"^[a-zA-ZÀ-ÿ\s]+$", ErrorMessage = "O campo {0} deve conter apenas letras.")]
  public string Name { get; set; } = null!;

  [Display(Name = "E-mail")]
  [Required(ErrorMessage = "O campo e-mail é obrigatório.")]
  [EmailAddress(ErrorMessage = "O campo E-mail deve ser um endereço de e-mail válido.")]
  public string Email { get; set; } = null!;

  [Display(Name = "CPF")]
  [Required(ErrorMessage = "O campo CPF é obrigatório.")]
  [RegularExpression(@"^[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}$", ErrorMessage = "Digite um CPF válido.")]
  public string CPF { get; set; } = null!;

  [Display(Name = "Senha")]
  [Required(ErrorMessage = "O campo senha é obrigatório.")]
  [DataType(DataType.Password)]
  public string Password { get; set; } = null!;

  [Display(Name = "CRO")]
  [Required(ErrorMessage = "O campo CRO é obrigatório.")]
  public string CRO { get; set; } = null!;

    public Dentist ToEntity()
  {
    var dentist = new Dentist
    {
      CRO = this.CRO,
      User = new User
      {
        Id = Guid.NewGuid().ToString(),
        UserType = UserTypes.Dentist,
        Name = this.Name,
        Email = this.Email,
        CPF = NumberOnly().Replace(this.CPF, ""),
        Password = BCrypt.Net.BCrypt.HashPassword(this.Password),
      }
    };
    return dentist;
  }

  [GeneratedRegex(@"\D")]
  private static partial Regex NumberOnly();
}