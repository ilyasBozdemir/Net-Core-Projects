using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.FluentValidation
{
    public class HouseValidator : AbstractValidator<House>
    {
        public HouseValidator()
        {

        }
    }
}
