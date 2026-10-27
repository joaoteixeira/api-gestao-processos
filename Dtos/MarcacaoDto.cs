using System.ComponentModel.DataAnnotations;

namespace ApiGestaoProcessos.Dtos
{
    public class MarcacaoDto
    {
        [Required(ErrorMessage = "O campo 'nome' é obrigatório")]
        public string Nome { get; set; } = string.Empty;
    }
}
