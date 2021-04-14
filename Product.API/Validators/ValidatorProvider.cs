using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Product.API.Mediatr.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Validators
{
    public static class ValidatorProvider
    {
        public static void BuildValidator(this IServiceCollection services)
        {
            //validator
            services.AddTransient<IValidator<AddProductRequest>, AddProductRequestValidator>();
            services.AddTransient<IValidator<UpdateProductRequest>, UpdateProductRequestValidator>();
        }
    }
}
