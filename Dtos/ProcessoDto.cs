
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiGestaoProcessos.Dtos
{
    public class ProcessoDto
    {

        [DefaultValue("PROC-123")]
        [SwaggerSchema("Número do Processo")]

        [Required(ErrorMessage = "O campo 'numero' é obrigatório")]
        
        public string Numero { get; set; } = string.Empty;

        [Required]
        [DefaultValue("2026-09-09")]
        public DateOnly Data { get; set; }

        [Required(ErrorMessage = "O campo 'interessado' é obrigatório")]
        [MinLength(5, ErrorMessage = "Obrigatório mínimo de 5 caracteres")]
        [DefaultValue("Pedro da Silva")]
        public string Interessado { get; set; } = string.Empty;

        [Required]
        [MinLength(5)]
        [DefaultValue("Solicitação de partilha de bens")]
        public string Assunto { get; set; } = string.Empty;

        [DefaultValue("Solicitação de partilha de bens")]
        public string? Descricao { get; set; }


    }

    public class ProcessoUpdateDto : ProcessoDto
    {
        public string? Situacao { get; set; }
    }

    //public class ProcessoDtoExample : IExamplesProvider<ProcessoDto>
    //{
    //    public ProcessoDto GetExamples()
    //    {
    //        return new ProcessoDto
    //        {
    //            Numero = "PROC-123",
    //            Data = DateOnly.
    //            Interessado = "João Junior"
    //        };
    //    }
    //}
}
