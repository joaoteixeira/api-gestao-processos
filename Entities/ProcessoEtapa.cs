using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiGestaoProcessos.Entities
{
    [Table("processo_etapa")]
    public class ProcessoEtapa
    {
        [Column("processo_id")]
        public int ProcessoId { get; set; }

        public Processo Processo { get; set; } = null!;

        [Column("etapa_id")]
        public int EtapaId { get; set; }

        public Etapa Etapa { get; set; } = null!;

        [Column("ordem")]
        public int Ordem { get; set; }

        [Column("data_inicio")]
        public DateTime? DataInicio { get; set; }

        [Column("data_conclusao")]
        public DateTime? DataConclusao { get; set; }

        [Column("status")]
        public string Status { get; set; } = "Pendente";

        [Column("observacao")]
        public string? Observacao { get; set; }
    }
}
