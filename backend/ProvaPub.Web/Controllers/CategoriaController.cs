using Microsoft.AspNetCore.Mvc;
using ProvaPub.Application.DTOs;
using ProvaPub.Application.Enums;
using ProvaPub.Application.Services;


namespace ProvaPub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
       
        [HttpGet]
        public async Task<IEnumerable<CategoriaDto>> Get()
        {
            return await _categoriaService.GetAll();
        }
        [HttpGet("Finalidades")]
        public async Task<IEnumerable<TipoDto>> GetFinalidades()
        {
            return new List<TipoDto> {
                                            new TipoDto{Id=(int)FinalidadeEnum.Despesa, Nome=FinalidadeEnum.Despesa.ToString() },
                                            new TipoDto{Id=(int)FinalidadeEnum.Receita, Nome=FinalidadeEnum.Receita.ToString() },
                                            new TipoDto{Id=(int)FinalidadeEnum.Ambos, Nome=FinalidadeEnum.Ambos.ToString() }
            };
        }

        [HttpGet("GetCategoriasResumo")]
        public async Task<IEnumerable<CategoriaResumoDto>> GetCategoriasResumo()
        {
            var categorias = await _categoriaService.GetCategoriasResumo();
            return categorias;
        }
        
        [HttpGet("{id}")]
        public async Task<CategoriaDto> Get(Guid id)
        {
            return await _categoriaService.GetCategoriaById(id);
        }

        [HttpGet("by-description/{description}")]
        public async Task<IEnumerable<CategoriaDto>> Get(string description)
        {
            return await _categoriaService.GetCategoriaByDescricao(description);
        }
       
        [HttpPost]
        public async Task Post([FromBody] CategoriaDto value)
        {
            await _categoriaService.AddAsync(value);
        }
        
        [HttpPut("{categoriaId}")]
        public async Task Put(Guid categoriaId, [FromBody] CategoriaDto value)
        {
            await _categoriaService.UpdateAsync(value);
        }
        
        [HttpDelete("{categoriaId}")]
        public async Task Delete(Guid categoriaId)
        {
            await _categoriaService.DeleteAsync(categoriaId);
        }
    }
}
