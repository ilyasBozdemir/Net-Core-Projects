using Domain.Entities;
using Domain.Entities.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

        }
    }
}
