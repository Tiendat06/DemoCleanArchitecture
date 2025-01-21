using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Demo.Application.DTOs.Account
{
    public class ChangeRoleRequest
    {
        public int AccountId { get; set; }
        public int RoleId { get; set; }
    }

    public class ChangeRoleRequestValidator : AbstractValidator<ChangeRoleRequest>
    {
        public ChangeRoleRequestValidator()
        {
            RuleFor(changeRoleRequest => changeRoleRequest.AccountId)
                .NotNull().WithMessage("Account Id is not exists !")
                .NotEmpty().WithMessage("Account Id is empty !");
            RuleFor(changeRoleRequest => changeRoleRequest.RoleId)
                .NotNull().WithMessage("Role Id is not exists !")
                .NotEmpty().WithMessage("Role Id is empty !");
        }
    }
}
