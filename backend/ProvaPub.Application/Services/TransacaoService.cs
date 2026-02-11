using ProvaPub.Application.DTOs;
using ProvaPub.Application.Enums;
using ProvaPub.Application.Exceptions;
using ProvaPub.Application.Extensions;
using ProvaPub.Application.Interfaces;

namespace ProvaPub.Application.Services
{
    public class TransacaoService
    {
        ITransacaoRepository _transacaoRepository;
        IPessoaRepository _pessooaRepository;
        ICategoriaRepository _categoriaRepository;
        public TransacaoService(ITransacaoRepository transacaoRepository, IPessoaRepository pessooaRepository, ICategoriaRepository categoriaRepository)
        {
            _transacaoRepository = transacaoRepository;
            _pessooaRepository = pessooaRepository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<TransacaoDto> AddAsync(TransacaoDto transacao)
        {
            if (transacao.Valor <= 0)
            {
                throw new BusinessException("A transação deve ter um valor maior ou igual a zero!");
            }

            if (!(await CheckIfCategoriaAndFinalidadeIsValid(transacao)))
            {
                throw new BusinessException("A finalidade da categoria e o tipo da transação devem corresponder!");
            }

            if (!(await CheckIfPessoaAndFinalidadeIsValid(transacao)))
            {
                throw new BusinessException("Pessoas menores de 18 anos podem apenas ter despesas!");
            }

            return (await _transacaoRepository.AddAsync(transacao.ToEntity())).ToDto();
        }

        public async Task<List<TransacaoDto>> GetAll()
        {
            return (await _transacaoRepository.GetAll()).ToDto();
        }

        public async Task<TransacaoDto> Get(Guid transacaoId)
        {
            return (await _transacaoRepository.Get(transacaoId)).ToDto();
        }


        public async Task<List<TransacaoDto>> GetByPessoa(Guid pessoaId)
        {
            return (await _transacaoRepository.GetAllByPessoa(pessoaId)).ToDto();
        }

        public async Task<List<TransacaoDto>> GetByCategoria(Guid categoriaId)
        {
            return (await _transacaoRepository.GetAllByCategoria(categoriaId)).ToDto();
        }

        public async Task UpdateAsync(TransacaoDto transacao)
        {
            await _transacaoRepository.UpdateAsync(transacao.ToEntity());

        }
        public async Task DeleteAsync(Guid id)
        {
            await _transacaoRepository.DeleteAsync(id);

        }

        private async Task<bool> CheckIfPessoaAndFinalidadeIsValid(TransacaoDto transacao)
        {
            var pessoa = await _pessooaRepository.GetPessoaById(transacao.PessoaId);

            var menorDeIdade = pessoa.DataNascimento > DateTime.Today.AddYears(-18);
            var tipoDespesa = (int)transacao.Tipo == (int)TipoEnum.Despesa;

            if (menorDeIdade && !tipoDespesa)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> CheckIfCategoriaAndFinalidadeIsValid(TransacaoDto transacao)
        {
            var categoria = await _categoriaRepository.GetCategoriaById(transacao.CategoriaId);
            var finalidade = (int)categoria.Finalidade;
            var tipo = (int)transacao.Tipo;

            if (finalidade == (int)FinalidadeEnum.Ambos)
            {
                return true;
            }

            if (finalidade == tipo)
            {
                return true;
            }

            return false;
        }
    }
}
