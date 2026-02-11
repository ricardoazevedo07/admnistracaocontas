using System.ComponentModel.DataAnnotations;

namespace ProvaPub.Domain.Entities
{
    public class Pessoa
    {
        [Key]
        public Guid PessoaId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }

        //Navegacao Reversa 
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
