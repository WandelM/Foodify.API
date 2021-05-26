using FluentValidation;
using Foodify.API.Dtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodify.API.Configurations
{
    public static class ValidatorsConfiguration
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<ProductCategoryInput>, ProductCategoryInputValidator>();
            services.AddTransient<IValidator<ProductCategoryUpdate>, ProductCategoryUpdateValidator>();
        }
    }
}
