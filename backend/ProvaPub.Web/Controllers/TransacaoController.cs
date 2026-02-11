using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProvaPub.Application.DTOs;
using ProvaPub.Application.Enums;
using ProvaPub.Application.Services;


namespace ProvaPub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {

        TransacaoService _transacaoService;

        public TransacaoController(TransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }
       
        [HttpGet]
        public async Task<IEnumerable<TransacaoDto>> Get()
        {
            return await _transacaoService.GetAll();
        }
        
        [HttpGet("Tipos")]
        public async Task<IEnumerable<TipoDto>> GetTipos()
        {
            return new List<TipoDto> {
                                            new TipoDto{Id=(int)TipoEnum.Despesa, Nome=TipoEnum.Despesa.ToString() },
                                            new TipoDto{Id=(int)TipoEnum.Receita, Nome=TipoEnum.Receita.ToString() }
            };
        }

        [HttpGet("{id}")]
        public async Task<TransacaoDto> Get(Guid id)
        {
            return await _transacaoService.Get(id);
        }

        [HttpGet("PessoaId/{pessoaId}")]
        public async Task<List<TransacaoDto>> GetByPessoa(Guid pessoaId)
        {
            return await _transacaoService.GetByPessoa(pessoaId);
        }

        [HttpGet("CategoriaId/{categoriaId}")]
        public async Task<List<TransacaoDto>> GetByCategoria(Guid categoriaId)
        {
            return await _transacaoService.GetByCategoria(categoriaId);
        }

        [HttpPost]
        public async Task Post([FromBody] TransacaoDto value)
        {
            await _transacaoService.AddAsync(value);
        }

        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] TransacaoDto value)
        {
            await _transacaoService.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _transacaoService.DeleteAsync(id);
        }
    }
}
