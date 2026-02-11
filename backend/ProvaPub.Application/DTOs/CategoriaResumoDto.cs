namespace ProvaPub.Application.DTOs
{
    public class CategoriaResumoDto
    {
        public Guid CategoriaId { get; set; }
        public ushort Finalidade { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }
        public decimal Saldo => TotalReceitas - TotalDespesas;
    }
}
