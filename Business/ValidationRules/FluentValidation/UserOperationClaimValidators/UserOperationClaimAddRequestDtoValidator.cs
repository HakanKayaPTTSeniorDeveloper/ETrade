using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimAddDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.UserOperationClaimValidators
{
    public class UserOperationClaimAddRequestDtoValidator : AbstractValidator<UserOperationClaimAddRequestDto>
    {
        public UserOperationClaimAddRequestDtoValidator()
        {

            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.UserId).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.OperationClaimId).NotNull();
            RuleFor(x => x.OperationClaimId).InclusiveBetween(short.MinValue, short.MaxValue);
        }
    }
}