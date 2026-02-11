using ProvaPub.Application.DTOs;
using ProvaPub.Domain.Entities;

namespace ProvaPub.Application.Interfaces
{
    public interface ICategoriaRepository
    {
        Task AddAsync(Categoria categoria);
        Task<Categoria> GetCategoriaById(Guid id);
        Task<List<Categoria>> GetCategoriaByDescricao(string descricao);
        Task<List<Categoria>> GetAll();
        Task DeleteAsync(Guid categoriaId);
        Task UpdateAsync(Categoria categoria);
        Task<List<CategoriaResumoDto>> GetCategoriasResumo();

    }
}
