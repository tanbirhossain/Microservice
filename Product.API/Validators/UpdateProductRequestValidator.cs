using FluentValidation;
using Product.API.Mediatr.Requests.Command;

namespace Product.API.Validators
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.Quantity).GreaterThan(1);
        }
    }
}
