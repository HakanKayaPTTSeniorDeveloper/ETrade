using AutoMapper;
using Core.Entities.Concrete.Entities;
using Entities.Concrete.Dtos.AuthDtos.AccessTokenDtoS;
using Entities.Concrete.Dtos.AuthDtos.RegisterDtos;
using Entities.Concrete.Dtos.UserDtos.UserAddDtos;
using Entities.Concrete.Dtos.UserDtos.UserGetByIdDtos;
using Entities.Concrete.Dtos.UserDtos.UserGetClaimsDtos;
using Entities.Concrete.Dtos.UserDtos.UserSearch;
using Entities.Concrete.Dtos.UserDtos.UserUpdateDtos;

namespace Business.Utilities.MappingProfiles
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserGetClaimsRequestDto>();
            CreateMap<UserGetClaimsRequestDto, User>();

            CreateMap<OperationClaim, UserGetClaimsResponseDto>();
            CreateMap<UserGetClaimsResponseDto, OperationClaim>();

            CreateMap<User, UserGetClaimsRequestDto>();
            CreateMap<UserGetClaimsRequestDto, User>();

            CreateMap<User, UserAddRequestDto>();
            CreateMap<UserAddRequestDto, User>();

            CreateMap<User, UserUpdateRequestDto>();
            CreateMap<UserUpdateRequestDto, User>();

            CreateMap<User, RegisterRequestDto>();
            CreateMap<RegisterRequestDto, User>();

            CreateMap<User, AccessTokenAddRequestDto>();
            CreateMap<AccessTokenAddRequestDto, User>();

            CreateMap<User, UserSearchRequestDto>();
            CreateMap<UserSearchRequestDto, User>();

            CreateMap<User, UserSearchResponseDto>();
            CreateMap<UserSearchResponseDto, User>();

            CreateMap<User, UserGetByIdResponseDto>();
            CreateMap<UserGetByIdResponseDto, User>();
        }
    }
}
