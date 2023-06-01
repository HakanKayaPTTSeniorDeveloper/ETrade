using Entities.Concrete.Dtos.AuthDtos.RegisterDtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.AuthValidators
{
    public class RegisterRequestDtoValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestDtoValidator()
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.UserName).Length(2, 200);

            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).Length(2, 50);

            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).Length(2, 50);


            RuleFor(x => x.Password).NotNull();
            
        }

    }
}
