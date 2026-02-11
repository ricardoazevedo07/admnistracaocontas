

using ProvaPub.Application.Enums;

namespace ProvaPub.Application.DTOs
{
    public class TransacaoDto
    {

        public Guid TransacaoId { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }

        public TipoEnum Tipo { get; set; }
        public Guid PessoaId { get; set; }

        public Guid CategoriaId { get; set; }

    }
}
