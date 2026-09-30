using ApiGestaoProcessos.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestaoProcessos.Dtos.Responses
{
    public class ProcessoResponseDto
    {
        public int Id { get; set; }

        public string Numero { get; set; } = string.Empty;

        public DateOnly Data { get; set; }

        public string Interessado { get; set; } = string.Empty;

        public string Assunto { get; set; } = string.Empty;

        public string? Descricao { get; set; }

        public string Situacao { get; set; } = "Aberto";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ClienteResponseDto? Cliente { get; set; }
    }
}
