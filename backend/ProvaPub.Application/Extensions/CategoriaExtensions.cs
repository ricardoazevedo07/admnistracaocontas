using ProvaPub.Application.DTOs;
using ProvaPub.Domain.Entities;

namespace ProvaPub.Application.Extensions
{
    public static class CategoriaExtensions
    {
        public static CategoriaDto ToDto(this Categoria entity)
        {
            return new CategoriaDto { CategoriaId = entity.CategoriaId, Descricao = entity.Descricao, Finalidade = (ProvaPub.Application.Enums.FinalidadeEnum)(int)entity.Finalidade };
        }

        public static List<CategoriaDto> ToDto(this ICollection<Categoria> entities)
        {
            return entities.Select(ToDto).ToList();
        }

        public static Categoria ToEntity(this CategoriaDto dto)
        {
            return new Categoria { CategoriaId = dto.CategoriaId.HasValue ? dto.CategoriaId.Value : Guid.NewGuid(), Descricao = dto.Descricao, Finalidade = (ProvaPub.Domain.Enums.FinalidadeEnum)(int)dto.Finalidade };
        }

        public static List<Categoria> ToEntity(this ICollection<CategoriaDto> Dtos)
        {
            return Dtos.Select(ToEntity).ToList();
        }
    }
}
