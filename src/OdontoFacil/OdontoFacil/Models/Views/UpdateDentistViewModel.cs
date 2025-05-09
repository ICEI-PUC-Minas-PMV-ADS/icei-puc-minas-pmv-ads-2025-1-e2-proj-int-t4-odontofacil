using System.ComponentModel.DataAnnotations;

namespace OdontoFacil.Models.Views;

public class UpdateDentistViewModel
{

  [Display(Name = "Nome completo")]
  public string Name { get; set; } = null!;

  [Display(Name = "CPF")]
  public string CPF { get; set; } = null!;

  [Display(Name = "E-mail")]
  [EmailAddress(ErrorMessage = "O campo E-mail deve ser um endereço de e-mail válido.")]
  public string Email { get; set; } = null!;

  [Display(Name = "CRO")]
  public string CRO { get; set; } = null!;
}