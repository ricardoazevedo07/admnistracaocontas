using Microsoft.EntityFrameworkCore;
using ProvaPub.Application.DTOs;
using ProvaPub.Application.Interfaces;
using ProvaPub.Domain.Entities;
using ProvaPub.Infra.Data.Context;

namespace ProvaPub.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        TestDbContext _context;
        public CategoriaRepository(TestDbContext context)
        {

            _context = context;
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();


        }

        public async Task<Categoria> GetCategoriaById(Guid id)
        {
            return await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(f => f.CategoriaId == id);
        }

        public async Task<List<CategoriaResumoDto>> GetCategoriasResumo()
        {
            var categorias = await _context.Categorias
        .Select(p => new CategoriaResumoDto
        {
            CategoriaId = p.CategoriaId,
            Nome = p.Descricao,
            Finalidade = (ushort)p.Finalidade,
            TotalReceitas = p.Transacoes
                .Where(t => t.Tipo == Domain.Enums.TipoEnum.Receita)
                .Sum(t => (decimal?)t.Valor) ?? 0,
            TotalDespesas = p.Transacoes
                .Where(t => t.Tipo == Domain.Enums.TipoEnum.Despesa)
                .Sum(t => (decimal?)t.Valor) ?? 0
        })
        .ToListAsync();

            return categorias;
        }

        public async Task<List<Categoria>> GetCategoriaByDescricao(string descricao)
        {
            return await _context.Categorias.Where(w => w.Descricao.Contains(descricao)).AsNoTracking().ToListAsync();
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid categoriaId)
        {
            await _context.Categorias.Where(w => w.CategoriaId == categoriaId).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }


    }
}
