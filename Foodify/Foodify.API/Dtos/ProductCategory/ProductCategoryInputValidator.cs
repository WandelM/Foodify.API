using FluentValidation;

namespace Foodify.API.Dtos
{
    public class ProductCategoryInputValidator : AbstractValidator<ProductCategoryInput>
    {
        public ProductCategoryInputValidator()
        {
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.Name).Length(1, 100);
        }
    }
}
