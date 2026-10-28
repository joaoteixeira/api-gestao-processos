using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiGestaoProcessos.Entities
{
    [Table("etapas"), PrimaryKey(nameof(Id))]
    public class Etapa
    {
        [Column("id_etapa")]
        public int Id { get; set; }

        [Column("nome_etapa")]
        public string Nome { get; set; } = string.Empty;

        [Column("descricao_etapa")]
        public string? Descricao { get; set; }

        public ICollection<ProcessoEtapa> ProcessosEtapas { get; set; } 
            = new List<ProcessoEtapa>();
    }
}
