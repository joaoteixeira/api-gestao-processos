using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiGestaoProcessos.Entities
{
    [Table("clientes"), PrimaryKey(nameof(Id))]
    public class Cliente
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        //[JsonIgnore]
        public ICollection<Processo>? Processos { get; set; }
    }
}
