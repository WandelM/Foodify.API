using FluentValidation;

namespace Foodify.API.Dtos
{
    public class ProductCategoryUpdateValidator : AbstractValidator<ProductCategoryUpdate>
    {
        public ProductCategoryUpdateValidator()
        {
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.Name).Length(1, 100);
        }
    }
}
