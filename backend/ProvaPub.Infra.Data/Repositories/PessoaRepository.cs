using Microsoft.EntityFrameworkCore;
using ProvaPub.Application.DTOs;
using ProvaPub.Application.Interfaces;
using ProvaPub.Domain.Entities;
using ProvaPub.Infra.Data.Context;

namespace ProvaPub.Infra.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        TestDbContext _context;
        public PessoaRepository(TestDbContext context)
        {

            _context = context;
        }

        public async Task<Pessoa> GetPessoaById(Guid pessoaId)
        {
            var pessoa = await _context.Pessoas.Include(i => i.Transacoes).AsNoTracking().FirstAsync(f => f.PessoaId == pessoaId);
            return pessoa;
        }
        public async Task<List<Pessoa>> GetAllPessoas()
        {
            return await _context.Pessoas.AsNoTracking().ToListAsync();
        }

        public async Task<List<PessoaResumoDto>> GetPessoasResumo()
        {
            var pessoas = await _context.Pessoas
        .Select(p => new PessoaResumoDto
        {
            PessoaId = p.PessoaId,
            Nome = p.Nome,
            TotalReceitas = p.Transacoes
                .Where(t => t.Tipo == Domain.Enums.TipoEnum.Receita)
                .Sum(t => (decimal?)t.Valor) ?? 0,
            TotalDespesas = p.Transacoes
                .Where(t => t.Tipo == Domain.Enums.TipoEnum.Despesa)
                .Sum(t => (decimal?)t.Valor) ?? 0
        })
        .ToListAsync();

            return pessoas;
        }
        public async Task<Pessoa> AddAsync(Pessoa pessoa)
        {
            var novaPessoa = (await _context.AddAsync(pessoa)).Entity;
            await _context.SaveChangesAsync();
            return novaPessoa;
        }

        public async Task UpdateAsync(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(Guid id)
        {
            await _context.Transacoes.Where(w => w.PessoaId == id).ExecuteDeleteAsync();
            await _context.Pessoas.Where(w => w.PessoaId == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }


    }
}
