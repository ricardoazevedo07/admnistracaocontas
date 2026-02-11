using ProvaPub.Application.DTOs;
using ProvaPub.Domain.Entities;

namespace ProvaPub.Application.Interfaces
{
    public interface IPessoaRepository
    {
        public Task<Pessoa> GetPessoaById(Guid pessoaId);
        public Task<List<Pessoa>> GetAllPessoas();
        public Task<Pessoa> AddAsync(Pessoa pessoa);
        public Task UpdateAsync(Pessoa pessoa);
        public Task DeleteAsync(Guid id);
        Task<List<PessoaResumoDto>> GetPessoasResumo();

    }
}
