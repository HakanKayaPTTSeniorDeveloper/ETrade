using Entities.Concrete.Dtos.UserDtos.UserAddDtos;
using Entities.Concrete.Dtos.UserDtos.UserSearch;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.UserValidators
{
    public class UserSearchRequestDtoValidator : AbstractValidator<UserSearchRequestDto>
    {
        public UserSearchRequestDtoValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).Length(0, 50);

            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).Length(0, 50);

            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.UserName).Length(0, 200);
        }
    }
}


