using ProvaPub.Domain.Entities;

namespace ProvaPub.Application.Interfaces
{
    public interface ITransacaoRepository
    {
        Task<Transacao> AddAsync(Transacao transacao);
        Task<List<Transacao>> GetAll();
        Task<List<Transacao>> GetAllByPessoa(Guid pessoaId);
        Task<List<Transacao>> GetAllByCategoria(Guid categoriaId);
        Task<Transacao> Get(Guid transacaoId);
        Task UpdateAsync(Transacao transacao);
        Task DeleteAsync(Guid id);

    }
}
