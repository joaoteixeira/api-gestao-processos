using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestaoProcessos.Dtos.Responses
{
    public class ClienteResponseDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;
    }
}
