using System.Collections.Generic;

namespace OdontoFacil.Models
{
    internal class DentistaViewModel
    {
        public required string Nome { get; set; }
        public required string Especialidade { get; set; }
        public required string Endereco { get; set; }
        public required Dictionary<string, List<string>> DiasDisponiveis { get; set; }
    }
}