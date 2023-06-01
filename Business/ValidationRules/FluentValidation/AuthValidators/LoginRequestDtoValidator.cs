using Entities.Concrete.Dtos.AuthDtos.LoginDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.AuthValidators
{
    public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestDtoValidator()
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.UserName).Length(2, 200);


            RuleFor(x => x.Password).NotNull();

        }
      
    }
}
