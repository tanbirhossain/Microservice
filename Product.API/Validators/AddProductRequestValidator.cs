using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Product.API.Mediatr.Requests.Command;

namespace Product.API.Validators
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.Quantity).GreaterThan(1);
        }
    }
}
