using System.ComponentModel.DataAnnotations;
using ProvaPub.Domain.Enums;

namespace ProvaPub.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public Guid CategoriaId { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public FinalidadeEnum Finalidade { get; set; }

        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
