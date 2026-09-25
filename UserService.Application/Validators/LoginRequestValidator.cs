using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.DTO;

namespace UserService.Application.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("this is not email");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6)
                .WithMessage("Password must be at least 6 characters.");

        }
    }
}
