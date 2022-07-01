using FluentValidation;
using IMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Business.ValidationRules.FluentValidation
{
    public class ApartmentValidator : AbstractValidator<Apartment>
    {
        public ApartmentValidator()
        {
            RuleFor(a => a.Id).NotNull();
            RuleFor(a => a.Name).Length(2, 30);
            RuleFor(a => a.Block).Length(2, 30);
            RuleFor(a => a.TotalFloors).GreaterThan(0);
        }
    }
}
