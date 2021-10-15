using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Dto;
using FluentValidation;

namespace Domain.Models
{
    public abstract class UserModelValidator : AbstractValidator<RegisterDto>
    {

        public void UserName() => RuleFor(user => user.UserName).NotEmpty();

        public void Email() => RuleFor(user => user.Email).EmailAddress();

        public void Password() => RuleFor(user => user.Password).NotEmpty();
    }
}
