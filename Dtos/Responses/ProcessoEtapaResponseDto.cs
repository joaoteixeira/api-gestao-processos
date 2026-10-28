using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestaoProcessos.Dtos.Responses
{
    public class ProcessoEtapaResponseDto
    {
        public string Nome { get; set; } = string.Empty;

        public int Ordem { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataConclusao { get; set; }

        public string Status { get; set; } = string.Empty;

        public string? Observacao { get; set; }
    }
}
