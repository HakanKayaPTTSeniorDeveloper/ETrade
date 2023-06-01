using Entities.Concrete.Dtos.UserDtos.UserAddDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.UserValidators
{
    public class UserGetClaimsRequestDtoValidator : AbstractValidator<UserAddRequestDto>
    {
        public UserGetClaimsRequestDtoValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).Length(2, 50);

            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).Length(2, 50);

            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.UserName).Length(2, 200);

            RuleFor(x => x.IsActive).NotNull();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);



        }
    }
}
