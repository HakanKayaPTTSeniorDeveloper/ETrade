using Entity.Concrete.Dtos.CategoryDtos.CategoryUpdateDtos;
using Entity.Concrete.Dtos.ProductDtos.ProductUpdateDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.ProductValidators
{
    public class ProductUpdateRequestDtoValidator : AbstractValidator<ProductUpdateRequestDto>
    {
        public ProductUpdateRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).Length(2, 50);
        }
    }
}