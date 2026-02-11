using ProvaPub.Application.DTOs;
using ProvaPub.Domain.Entities;

namespace ProvaPub.Application.Extensions
{
    internal static class PessoaExtensions
    {
        public static PessoaDto ToDto(this Pessoa entity)
        {
            return new PessoaDto { PessoaId = entity.PessoaId, DataNascimento = entity.DataNascimento, Nome = entity.Nome };
        }

        public static List<PessoaDto> ToDto(this ICollection<Pessoa> entities)
        {
            return entities.Select(entity => ToDto(entity)).ToList();
        }

        public static Pessoa ToEntity(this PessoaDto dto)
        {
            return new Pessoa { PessoaId = dto.PessoaId, DataNascimento = dto.DataNascimento, Nome = dto.Nome };
        }

        public static List<Pessoa> ToEntity(this ICollection<PessoaDto> Dtos)
        {
            return Dtos.Select(ToEntity).ToList();
        }
    }
}
