using Entity.Concrete.Dtos.ProductDtos.ProductAddDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.ProductValidators
{
    public class ProductAddRequestDtoValidator : AbstractValidator<ProductAddRequestDto>
    {
        public ProductAddRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).Length(2,50);
        }
    }
}