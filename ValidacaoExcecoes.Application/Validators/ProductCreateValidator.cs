using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacaoExececoes.Core.Entities;

namespace ValidacaoExcecoes.Application.Validators
{
    public class productCreateValidator : AbstractValidator<Product>
    {
        public productCreateValidator()
        {
            RuleFor(p => p.Preco)
                .Must(v=>v>0);
            RuleFor(p => p.Nome).MinimumLength(3);
        }
    }
}
