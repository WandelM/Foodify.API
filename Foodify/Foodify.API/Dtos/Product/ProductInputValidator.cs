using FluentValidation;

namespace Foodify.API.Dtos.Product
{
    public class ProductInputValidator : AbstractValidator<ProductInput>
    {
        public ProductInputValidator()
        {
            RuleFor(p => p.Name).NotNull()
                                .NotEmpty()
                                .Length(3, 200)
                                .WithMessage($"Name has to have lenght of 3-200 characters.");

            RuleFor(p => p.ProductCategoryId).NotNull()
                                             .WithMessage("Product has to have a category.");

            RuleFor(p => p.Calories).NotNull()
                                    .GreaterThanOrEqualTo(0)
                                    .WithMessage("Calories has to have value more then 0");

            RuleFor(p => p.Carbs).NotNull()
                                 .GreaterThanOrEqualTo(0)
                                 .WithMessage("Carbs has to have value more then 0");

            RuleFor(p => p.Protein).NotNull()
                                   .GreaterThanOrEqualTo(0)
                                   .WithMessage("Protein has to have value more then 0");

            RuleFor(p => p.Fat).NotNull()
                               .GreaterThanOrEqualTo(0)
                               .WithMessage("Fat has to have value more then 0");
        }
    }
}
