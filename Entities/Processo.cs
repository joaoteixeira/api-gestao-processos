using ApiGestaoProcessos.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestaoProcessos.Entities
{
    [Table("processos"), PrimaryKey(nameof(Id))]
    public class Processo
    {
        [Column("id_pro")]
        public int Id { get; set; }

        [Column("numero_pro")]
        public string Numero { get; set; } = string.Empty;

        [Column("data_pro")]
        public DateOnly Data { get; set; }

        [Column("interessado_pro")]
        public string Interessado { get; set; } = string.Empty;

        [Column("assunto_pro")]
        public string Assunto { get; set; } = string.Empty;

        [Column("descricao_pro")]
        public string? Descricao { get; set; }

        [Column("situacao_pro")]
        public SituacaoEnum Situacao { get; set; } = SituacaoEnum.Aberto;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}