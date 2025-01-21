using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Demo.Application.DTOs.Auth
{
    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(loginRequest => loginRequest.Email)
                .NotNull().WithMessage("Email field is not exists !")
                .NotEmpty().WithMessage("Email is empty !")
                .EmailAddress().WithMessage("Invalid Email !");
            RuleFor(loginRequest => loginRequest.Password)
                .NotNull().WithMessage("Password field is not exists !")
                .NotEmpty().WithMessage("Password is empty !");
        }
    }
}
