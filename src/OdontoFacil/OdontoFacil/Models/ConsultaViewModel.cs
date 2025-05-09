using System;

namespace OdontoFacil.Models
{
    public class ConsultaViewModel
    {
        public DateTime Data { get; set; }
        public string Status { get; set; } = string.Empty;
        public string LinkDocumento { get; set; } = string.Empty;
    }

}