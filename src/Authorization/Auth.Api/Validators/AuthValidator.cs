using Auth.Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Api.Validators
{
    public class AuthValidator : AbstractValidator<AuthRequest>
    {
        public AuthValidator()
        {
            RuleFor(_ => _.Email)
                .EmailAddress();

            RuleFor(_ => _.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5);
        }
    }
}
