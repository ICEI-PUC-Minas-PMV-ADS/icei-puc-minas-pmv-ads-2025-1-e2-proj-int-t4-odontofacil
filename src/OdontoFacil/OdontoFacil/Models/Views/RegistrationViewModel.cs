using System.ComponentModel.DataAnnotations;

namespace OdontoFacil.Models.Views;

public class RegistrationViewModel
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

    [Display(Name = "Aceitar os termos de uso")]
    [DeniedValues(false, ErrorMessage = "Você deve aceitar os termos de uso.")]
    public bool TermsAccepted { get; set; } = false;
}