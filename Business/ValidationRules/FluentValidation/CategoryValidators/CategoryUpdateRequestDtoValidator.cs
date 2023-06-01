using Entity.Concrete.Dtos.CategoryDtos.CategoryUpdateDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CategoryValidators
{
    public class CategoryUpdateRequestDtoValidator : AbstractValidator<CategoryUpdateRequestDto>
    {
        public CategoryUpdateRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).Length(2, 50);
        }
    }
}