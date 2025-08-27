using System.ComponentModel.DataAnnotations;
using ValidacaoExcecoes.Core.Entities;

namespace ValidacaoExcecoes.Application.ViewModels.UserModels
{
    public class UserCreateModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        
        [Required]
        [StringLength(16,MinimumLength =8)]
        public string Senha { get; set; }
        
        [Required]
        [Compare("Senha", ErrorMessage ="As senhas não Coincidem")]
        public string ConfirmacaoSenha { get; set; }

        public User ToEntity() => new User(Nome, Email, CPF, DataNascimento, Senha);
    }
}
