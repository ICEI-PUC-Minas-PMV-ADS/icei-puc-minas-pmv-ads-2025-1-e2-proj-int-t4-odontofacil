using System;
using System.ComponentModel.DataAnnotations;

namespace OdontoFacil.Models.Views
{
    public class PatientListViewModel
    {
        public string? Id { get; set; }
        [Display(Name = "Nome")]
        public string? Name { get; set; }
        [Display(Name = "CPF")]
        public string? CPF { get; set; }
        [Display(Name = "Idade")]
        public int Age { get; set; }
    }
}