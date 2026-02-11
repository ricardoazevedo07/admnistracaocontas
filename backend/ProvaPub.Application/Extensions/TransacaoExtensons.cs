using ProvaPub.Application.DTOs;
using ProvaPub.Domain.Entities;

namespace ProvaPub.Application.Extensions
{
    public static class TransacaoExtensons
    {
        public static TransacaoDto ToDto(this Transacao entity)
        {
            return new TransacaoDto { CategoriaId = entity.CategoriaId, Descricao = entity.Descricao, PessoaId = entity.PessoaId, Tipo = (ProvaPub.Application.Enums.TipoEnum)entity.Tipo, TransacaoId = entity.TransacaoId, Valor = entity.Valor };
        }

        public static List<TransacaoDto> ToDto(this ICollection<Transacao> entities)
        {
            return entities.Select(entity => ToDto(entity)).ToList();
        }

        public static Transacao ToEntity(this TransacaoDto dto)
        {
            return new Transacao { CategoriaId = dto.CategoriaId, Descricao = dto.Descricao, PessoaId = dto.PessoaId, Tipo = (ProvaPub.Domain.Enums.TipoEnum)dto.Tipo, TransacaoId = dto.TransacaoId, Valor = dto.Valor };
        }

        public static ICollection<Transacao> ToEntity(this IEnumerable<TransacaoDto> Dtos)
        {
            return Dtos.Select(dto => ToEntity(dto)).ToList();
        }

        public static ICollection<Transacao> ToEntity(this List<TransacaoDto> Dtos)
        {
            return Dtos.Select(dto => ToEntity(dto)).ToList();
        }
    }
}
