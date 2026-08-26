using System.ComponentModel.DataAnnotations;

namespace ApiGestaoProcessos.Dtos
{
    public class ProcessoDto
    {
        [Required(ErrorMessage = "O campo 'numero' é obrigatório")]
        public required string Numero { get; set; }

        [Required]
        public DateOnly Data { get; set; }

        [Required(ErrorMessage = "O campo 'interessado' é obrigatório")]
        [MinLength(5, ErrorMessage = "Obrigatório mínimo de 5 caracteres")]
        public required string Interessado { get; set; }

        [Required]
        [MinLength(5)]
        public required string Assunto { get; set; }

        public string? Descricao { get; set; }
    }

    public class ProcessoUpdateDto : ProcessoDto
    {
        public string? Situacao { get; set; }
    }
}
