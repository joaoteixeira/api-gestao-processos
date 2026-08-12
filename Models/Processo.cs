namespace ApiGestaoProcessos.Models
{
    public class Processo
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; } = string.Empty;

        public string Status {  get; set; } = string.Empty;

        public static List<Processo> Lista { get; set; }  = new List<Processo>()
        {
            new() { Nome = "Contratação", Status = "Em andamento"},
            new() { Nome = "Licitação", Status = "Aguardando Aprovação" },
            new() { Nome = "Pagamento de fornecedor", Status = "Concluído" }
        };
    }
}
