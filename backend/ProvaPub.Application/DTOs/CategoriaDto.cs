
using ProvaPub.Application.Enums;

namespace ProvaPub.Application.DTOs
{
    public class CategoriaDto
    {

        public Guid? CategoriaId { get; set; }

        public string Descricao { get; set; }

        public FinalidadeEnum Finalidade { get; set; }


    }
}
