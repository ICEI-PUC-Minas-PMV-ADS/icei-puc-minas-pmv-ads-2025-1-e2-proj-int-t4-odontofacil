using System.ComponentModel.DataAnnotations;

namespace OdontoFacil.Models.Views;

public class ProfileViewModel
{

    public string? Id { get; set; } = null!;

    [Display(Name = "Nome completo")]
    public string? Name { get; set; } = null!;

    [Display(Name = "CPF")]
    public string? CPF { get; set; } = null!;

    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "O campo e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo E-mail deve ser um endereço de e-mail válido.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Número de Celular")]
    [Required(ErrorMessage = "O campo Número de Celular é obrigatório.")]
    public string Phone { get; set; } = null!;

    [Display(Name = "Data de nascimento")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "O campo data de nascimento é obrigatório.")]
    public DateOnly? DateOfBirth { get; set; } = null!;

    [Display(Name = "Senha")]
    [DataType(DataType.Password)]
    public string? Password { get; set; } = null!;
}