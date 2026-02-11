using Microsoft.AspNetCore.Mvc;
using ProvaPub.Application.DTOs;
using ProvaPub.Application.Services;

namespace ProvaPub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        PessoaService _pessoaService;
        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }
       
        [HttpGet]
        public async Task<IEnumerable<PessoaDto>> Get()
        {
            return await _pessoaService.GetAllPessoas();
        }

        
        [HttpGet("{id}")]
        public async Task<PessoaDto> Get(Guid id)
        {
            var pessoa = await _pessoaService.GetPessoaById(id);
            return pessoa;
        }

        [HttpGet("GetPessoasResumo")]
        public async Task<List<PessoaResumoDto>> PessoasResumo()
        {
            var pessoa = await _pessoaService.GetPessoasResumo();
            return pessoa;
        }
       
        [HttpPost]
        public async Task Post([FromBody] PessoaDto novaPessoa)
        {
            await _pessoaService.AddAsync(novaPessoa);
        }

        [HttpPut("{pessoaId}")]
        public async Task Put(Guid pessoaId, [FromBody] PessoaDto value)
        {
            await _pessoaService.UpdateAsync(value);
        }
        
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _pessoaService.DeleteAsync(id);
        }
    }
}
