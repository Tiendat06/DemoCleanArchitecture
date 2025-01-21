using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Demo.Application.DTOs.User
{
    public class UpdateUserRequest
    {
        public string? Name { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
    }

    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(updateUserRequest => updateUserRequest.Name)
                .NotNull().WithMessage("Name is not exist !")
                .NotEmpty().WithMessage("Name is requried !");
            RuleFor(updateUserRequest => updateUserRequest.Email)
                .NotNull().WithMessage("Email is required !")
                .NotEmpty().WithMessage("Email is required !")
                .EmailAddress().WithMessage("Invalid email !");
            RuleFor(updateUserRequest => updateUserRequest.UserName)
                .NotNull().WithMessage("User name is not exists !")
                .NotEmpty().WithMessage("User name is required !");
        }
    }
}
