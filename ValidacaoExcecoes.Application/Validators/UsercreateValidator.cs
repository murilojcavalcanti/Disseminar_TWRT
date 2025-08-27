using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacaoExcecoes.Application.ViewModels.UserModels;

namespace ValidacaoExcecoes.Application.Validators
{
    public class UserCreateValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateValidator()
        {
            RuleFor(u => u.DataNascimento)
                .Must(d =>d < DateTime.Now.AddYears(-18))
                .WithMessage("O usuario deve mais de 18 anos");
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Email Inválido");
            RuleFor(u => u.Senha)
                .Equal(u => u.ConfirmacaoSenha).WithMessage("Senhas devem ser iguais!")
                .NotEmpty().WithMessage("Senha é obrigatória")
                .MinimumLength(8).WithMessage("A senha deve ter pelo menos 8 caracteres")
                .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula")
                .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula")
                .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número")
                .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter pelo menos um caractere especial");
            RuleFor(u => u.CPF).NotEmpty().WithMessage("CPF é obrigatório")
                .Must(ValidarCpf).WithMessage("CPF Inválido!");
        }
        private bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], cpf.Length) == cpf)
                return false;

            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            string digito = resto.ToString();

            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
