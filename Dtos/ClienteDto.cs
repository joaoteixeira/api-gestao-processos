using System.ComponentModel.DataAnnotations;

namespace ApiGestaoProcessos.Dtos
{
    public class ClienteDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
    }
}
