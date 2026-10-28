using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestaoProcessos.Dtos.Responses
{
    public class EtapaResponseDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string? Descricao { get; set; }
    }
}
