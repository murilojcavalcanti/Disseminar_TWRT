using System.ComponentModel.DataAnnotations;

namespace ValidacaoExcecoes.Core.Entities
{
    public class User
    {
        public User(string nome, string email, string cPF, DateTime dataNascimento, string senha)
        {
            Nome = nome;
            Email = email;
            CPF = cPF;
            DataNascimento = dataNascimento;
            Senha = senha;
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(11)]
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        [StringLength(16,MinimumLength =8)]
        public string Senha { get; set; }
    }
}
