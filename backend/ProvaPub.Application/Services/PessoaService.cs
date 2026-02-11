using ProvaPub.Application.DTOs;
using ProvaPub.Application.Extensions;
using ProvaPub.Application.Interfaces;

namespace ProvaPub.Application.Services
{
    public class PessoaService
    {
        IPessoaRepository _pessoaRepository;
        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }


        public async Task<PessoaDto> GetPessoaById(Guid pessoaId)
        {
            var pessoa = (await _pessoaRepository.GetPessoaById(pessoaId)).ToDto();
            return pessoa;
        }
        public async Task<List<PessoaDto>> GetAllPessoas()
        {
            return (await _pessoaRepository.GetAllPessoas()).ToDto() as List<PessoaDto>;
        }
        public async Task<PessoaDto> AddAsync(PessoaDto pessoa)
        {
            var novaPessoa = await _pessoaRepository.AddAsync(pessoa.ToEntity());
            return novaPessoa.ToDto();
        }

        public async Task UpdateAsync(PessoaDto pessoa)
        {
            await _pessoaRepository.UpdateAsync(pessoa.ToEntity());
        }

        public async Task DeleteAsync(Guid id)
        {
            await _pessoaRepository.DeleteAsync(id);
        }

        public async Task<List<PessoaResumoDto>> GetPessoasResumo()
        {
            return await _pessoaRepository.GetPessoasResumo();
        }
    }
}
