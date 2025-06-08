namespace OdontoFacil.Models.Views
{
    public class AnamneseViewModel
    {
        public string PacienteId { get; set; }

        public List<PerguntaResposta> Perguntas { get; set; }

        public class PerguntaResposta
        {
            public string? Id { get; set; }
            public string PerguntaId { get; set; }
            public string Descricao { get; set; }
            public bool? Resposta { get; set; }
            public string? RespostaTextual { get; set; }
        }
    }
}
