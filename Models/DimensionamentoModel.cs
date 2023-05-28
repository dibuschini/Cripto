namespace Dimensiona.Models
{
    public class DimensionamentoModel
    {
        public int Id { get; set; }
        public string? Cliente { get; set; }
        public string? Endereco { get; set; }
        public string? Comprimento { get; set; }
        public string? Largura { get; set; }
        public string? ProfundidadeMin { get; set; }
        public string? ProfundidadeMax { get; set; }
        public string? UsoPiscina { get; set; }
    }
}
