using AutoMapper;
using Core.Entities.Concrete.Entities;
using Entities.Concrete.Dtos.AuthDtos.GetByUserNameDto;

namespace Entities.Utilities.MappingProfiles
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {

            CreateMap<User, GetByUserNameResponseDto>();
            CreateMap<GetByUserNameResponseDto, User>();
        }

    }
}
