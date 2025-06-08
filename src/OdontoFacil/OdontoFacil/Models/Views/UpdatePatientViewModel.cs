using System;
using System.ComponentModel.DataAnnotations;
using OdontoFacil.Models.Data;

namespace OdontoFacil.Models.Views
{
  public class UpdatePatientViewModel
  {
        public UpdatePatientViewModel()
    {
    }

    public UpdatePatientViewModel(Patient patient)
    {
            ArgumentNullException.ThrowIfNull(patient);

            Id = patient.Id;

      if (patient.User != null)
      {
        Name = patient.User.Name;
        Email = patient.User.Email;
        CPF = patient.User.CPF;
      }

            PhoneNumber = patient.PhoneNumber;

      if (patient.DateOfBirth.HasValue)
        DateOfBirth = new DateTime(patient.DateOfBirth.Value.Year,
                                   patient.DateOfBirth.Value.Month,
                                   patient.DateOfBirth.Value.Day);

            Sex = patient.Sex;

      if (patient.HealthPlan != null)
      {
        HealthPlanId = patient.HealthPlan.Id;
      }

      if (patient.Address != null)
      {
        CEP = patient.Address.Cep;
        Street = patient.Address.Street;
        Number = patient.Address.Number ?? string.Empty;
        Complement = patient.Address.Complement ?? string.Empty;
        Neighborhood = patient.Address.Neighborhood;
        City = patient.Address.City;
        State = patient.Address.State;
      }
    }

    public string Id { get; set; }

    [Display(Name = "Nome completo")]
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Name { get; set; }

    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }

    [Display(Name = "CPF")]
    [Required(ErrorMessage = "O CPF é obrigatório")]
    public string CPF { get; set; }

    [Display(Name = "Telefone")]
    [Required(ErrorMessage = "O telefone é obrigatório")]
    public string PhoneNumber { get; set; }

    [Display(Name = "Data de Nascimento")]
    [Required(ErrorMessage = "A data de nascimento é obrigatória")]
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    [Display(Name = "Sexo")]
    [Required(ErrorMessage = "O sexo é obrigatório")]
    public string Sex { get; set; }

    [Display(Name = "CEP")]
    [Required(ErrorMessage = "O CEP é obrigatório")]
    public string CEP { get; set; }

    [Display(Name = "Rua")]
    [Required(ErrorMessage = "A rua é obrigatória")]
    public string Street { get; set; }

    [Display(Name = "Número")]
    [Required(ErrorMessage = "O número é obrigatório")]
    public string Number { get; set; }

    [Display(Name = "Complemento")]
    public string? Complement { get; set; }

    [Display(Name = "Bairro")]
    [Required(ErrorMessage = "O bairro é obrigatório")]
    public string Neighborhood { get; set; }

    [Display(Name = "Cidade")]
    [Required(ErrorMessage = "A cidade é obrigatória")]
    public string City { get; set; }

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "O estado é obrigatório")]
    public string State { get; set; }

    [Display(Name = "Convênio")]
    public string? HealthPlanId { get; set; }
  }

}