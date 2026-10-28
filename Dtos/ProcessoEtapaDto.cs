using System.ComponentModel.DataAnnotations;

namespace ApiGestaoProcessos.Dtos
{
    public class ProcessoEtapaDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int EtapaId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Ordem { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataConclusao { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        public string? Observacao { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(
                DataConclusao is not null && 
                DataInicio is not null &&
                DataConclusao < DataInicio
            )
            {
                yield return new ValidationResult(
                    "A data de conclusão não pode ser anterior à data de início",
                    [nameof(DataInicio), nameof(DataConclusao)]
                );
            }
        }
    }
}
