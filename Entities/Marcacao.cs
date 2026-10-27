using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestaoProcessos.Entities
{
    [Table("marcacoes"), PrimaryKey(nameof(Id))]
    public class Marcacao
    {
        [Column("id_mar")]
        public int Id { get; set; }

        [Column("nome_mar")]
        public string Nome { get; set; } = string.Empty;

        // Lado "muitos" do relacionamento N:N com Processo
        public ICollection<Processo>? Processos { get; set; }
    }
}
