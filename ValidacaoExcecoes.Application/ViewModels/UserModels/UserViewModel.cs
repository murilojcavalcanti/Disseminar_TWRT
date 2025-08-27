using System.ComponentModel.DataAnnotations;
using ValidacaoExcecoes.Core.Entities;

namespace ValidacaoExcecoes.Application.Models.UserModels
{
    public class UserViewModel
    {
        public UserViewModel(string nome, string email, string cPF, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            CPF = cPF;
            DataNascimento = dataNascimento;
        }

        [Required]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }

        public static UserViewModel FromEntity(User user) => new(user.Nome,user.Email,user.CPF,user.DataNascimento);
    }
}
