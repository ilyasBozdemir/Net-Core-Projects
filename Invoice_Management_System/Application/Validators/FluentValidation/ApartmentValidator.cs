using Domain.Entities;
using FluentValidation;


namespace Application.Validators.FluentValidation
{
    public class ApartmentValidator : AbstractValidator<Apartment>
    {
        public ApartmentValidator()
        {
            RuleFor(a => a.Id).NotNull().WithMessage("");
            RuleFor(a => a.Name).Length(2, 30).WithMessage("");
            RuleFor(a => a.Block).Length(2, 30).WithMessage("");
            RuleFor(a => a.TotalFloors).GreaterThan(0).WithMessage("");
        }
    }
}
