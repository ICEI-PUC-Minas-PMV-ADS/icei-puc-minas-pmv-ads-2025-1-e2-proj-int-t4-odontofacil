using System.ComponentModel.DataAnnotations;

namespace OdontoFacil.Models.Views;

public class LoginViewModel
{
    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "O campo e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo E-mail deve ser um endereço de e-mail válido.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Senha")]
    [Required(ErrorMessage = "O campo senha é obrigatório.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}