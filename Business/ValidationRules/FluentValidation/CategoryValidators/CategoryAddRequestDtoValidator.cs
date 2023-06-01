using Entity.Concrete.Dtos.CategoryDtos.CatagoryAddDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CategoryValidators
{
    public class CategoryAddRequestDtoValidator : AbstractValidator<CategoryAddRequestDto>
    {
        public CategoryAddRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).Length(2,50);
        }
    }
}