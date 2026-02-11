

namespace ProvaPub.Application.DTOs
{
    public class PessoaDto
    {

        public Guid PessoaId { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public int Idade
        {
            get {
                int anos = DateTime.Now.Year - DataNascimento.Year;

                // Ajusta se o aniversário ainda não passou no ano atual
                if (DateTime.Now < DataNascimento.AddYears(anos))
                {
                    anos--;
                }
                return anos;
            }
        }

    }
}
