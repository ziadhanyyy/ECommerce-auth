using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.DTO;

namespace UserService.Application.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("this is not email");
            RuleFor(x => x.name).NotEmpty().MinimumLength(3).WithMessage("name must be at least 3 characters.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6)
                .WithMessage("Password must be at least 6 characters.");
            
        }
    }
}
