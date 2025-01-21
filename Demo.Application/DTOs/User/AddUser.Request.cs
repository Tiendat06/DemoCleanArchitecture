using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Identity.Client;

namespace Demo.Application.DTOs.User
{
    public class AddUserRequest
    {
        public string? Name { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        public string? Password { get; set; } = null;
    }

    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            RuleFor(addUserRequest => addUserRequest.Name)
                .NotNull().WithMessage("Name is not exist !")
                .NotEmpty().WithMessage("Name is requried !");
            RuleFor(addUserRequest => addUserRequest.Email)
                .NotNull().WithMessage("Email is required !")
                .NotEmpty().WithMessage("Email is required !")
                .EmailAddress().WithMessage("Invalid email !");
            RuleFor(addUserRequest => addUserRequest.UserName)
                .NotNull().WithMessage("User name is not exists !")
                .NotEmpty().WithMessage("User name is required !");
            RuleFor(addUserRequest => addUserRequest.Password)
                .NotNull().WithMessage("Password is not exists !")
                .NotEmpty().WithMessage("Password is required !")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");
        }
    }
}
