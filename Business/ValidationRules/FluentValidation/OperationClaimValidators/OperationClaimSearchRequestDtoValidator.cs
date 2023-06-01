
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimSearch;
using FluentValidation;


namespace Business.ValidationRules.FluentValidation.OperationClaimValidators
{
    public class OperationClaimSearchRequestDtoValidator : AbstractValidator<OperationClaimSearchRequestDto>
    {
        public OperationClaimSearchRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).Length(0, 50);
        }
    }
}
