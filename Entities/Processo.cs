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
        public required string Interessado { get; set; }

        [Column("assunto_pro")]
        public required string Assunto { get; set; }

        [Column("descricao_pro")]
        public string? Descricao { get; set; }

        [Column("situacao_pro")]
        public string Situacao { get; set; } = "Aberto";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}