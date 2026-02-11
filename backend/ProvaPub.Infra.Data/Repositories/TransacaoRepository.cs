using Microsoft.EntityFrameworkCore;
using ProvaPub.Application.Interfaces;
using ProvaPub.Domain.Entities;
using ProvaPub.Infra.Data.Context;

namespace ProvaPub.Infra.Data.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        TestDbContext _context;
        public TransacaoRepository(TestDbContext context)
        {

            _context = context;
        }

        public async Task<Transacao> AddAsync(Transacao transacao)
        {
            var novaTransacao = (await _context.Transacoes.AddAsync(transacao)).Entity;
            await _context.SaveChangesAsync();
            return novaTransacao;
        }
        public async Task<List<Transacao>> GetAll()
        {
            return await _context.Transacoes.Include(i => i.Pessoa).Include(i => i.Categoria).AsNoTracking().ToListAsync();
        }
        public async Task<List<Transacao>> GetAllByPessoa(Guid pessoaId)
        {
            return await _context.Transacoes.Where(w => w.PessoaId == pessoaId).Include(i => i.Pessoa).Include(i => i.Categoria).AsNoTracking().ToListAsync();
        }
        public async Task<List<Transacao>> GetAllByCategoria(Guid categoriaId)
        {
            return await _context.Transacoes.Where(w => w.CategoriaId == categoriaId).Include(i => i.Pessoa).Include(i => i.Categoria).AsNoTracking().ToListAsync();
        }
        public async Task<Transacao> Get(Guid transacaoId)
        {
            return await _context.Transacoes.FindAsync(transacaoId);
        }
        public async Task UpdateAsync(Transacao transacao)
        {
            _context.Transacoes.Update(transacao);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            await _context.Transacoes.Where(w => w.TransacaoId == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }
    }
}
