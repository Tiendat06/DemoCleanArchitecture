using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Demo.Application.DTOs.Account
{
    public class ResetPasswordRequest
    {
        public int AccountId { get; set; }
    }

    public class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordRequestValidator()
        {
            RuleFor(resetPasswordRequest => resetPasswordRequest.AccountId)
                .NotNull().WithMessage("Account Id is not exists !")
                .NotEmpty().WithMessage("Account Id is empty !");
        }
    }
}
