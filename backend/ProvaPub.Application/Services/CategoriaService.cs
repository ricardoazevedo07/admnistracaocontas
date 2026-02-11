using ProvaPub.Application.DTOs;
using ProvaPub.Application.Exceptions;
using ProvaPub.Application.Extensions;
using ProvaPub.Application.Interfaces;

namespace ProvaPub.Application.Services
{
    public class CategoriaService
    {
        ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task AddAsync(CategoriaDto categoria)
        {
            if (categoria.Descricao.Length > 400)
            {
                throw new BusinessException("A descrição deve conter até 400 caracteres!");
            }
            await _categoriaRepository.AddAsync(categoria.ToEntity());
        }

        public async Task<CategoriaDto> GetCategoriaById(Guid id)
        {
            return (await _categoriaRepository.GetCategoriaById(id)).ToDto();
        }

        public async Task<List<CategoriaResumoDto>> GetCategoriasResumo()
        {
            return await _categoriaRepository.GetCategoriasResumo();
        }

        public async Task<List<CategoriaDto>> GetCategoriaByDescricao(string descricao)
        {
            return (await _categoriaRepository.GetCategoriaByDescricao(descricao)).ToDto() as List<CategoriaDto>;
        }

        public async Task<List<CategoriaDto>> GetAll()
        {
            return (await _categoriaRepository.GetAll()).ToDto() as List<CategoriaDto>;
        }
        public async Task UpdateAsync(CategoriaDto categoria)
        {
            await _categoriaRepository.UpdateAsync(categoria.ToEntity());
        }

        public async Task DeleteAsync(Guid id)
        {
            await _categoriaRepository.DeleteAsync(id);
        }

    }
}
