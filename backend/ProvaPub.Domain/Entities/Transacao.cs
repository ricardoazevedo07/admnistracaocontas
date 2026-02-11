using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProvaPub.Domain.Enums;

namespace ProvaPub.Domain.Entities
{
    public class Transacao
    {
        [Key]
        public Guid TransacaoId { get; set; }
        [MaxLength(400)]
        public string Descricao { get; set; }
        [Required]
        public float Valor { get; set; }
        [Required]
        public TipoEnum Tipo { get; set; }

        [Required]
        [ForeignKey(nameof(Pessoa))]
        public Guid PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        [Required]
        [ForeignKey(nameof(Categoria))]
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }
}
