using AutoMapper;
using Core.Entities.Concrete.Entities;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimAddDtos;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimGetByIdDtos;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimGetByUserIdDtos;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimGetListDtos;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimUpdateDtos;

namespace Business.Utilities.MappingProfiles
{
    public class UserOperationClaimMappingProfile:Profile
    {
        public UserOperationClaimMappingProfile()
        {
            CreateMap<UserOperationClaim, UserOperationClaimAddRequestDto>();
            CreateMap<UserOperationClaimAddRequestDto, UserOperationClaim>();

            CreateMap<UserOperationClaim, UserOperationClaimGetByIdResponseDto>();
            CreateMap<UserOperationClaimGetByIdResponseDto, UserOperationClaim>();

            CreateMap<UserOperationClaim, UserOperationClaimGetListResponseDto>();
            CreateMap<UserOperationClaimGetListResponseDto, UserOperationClaim>();

            CreateMap<UserOperationClaim, UserOperationClaimUpdateRequestDto>();
            CreateMap<UserOperationClaimUpdateRequestDto, UserOperationClaim>();

            CreateMap<UserOperationClaim, UserOperationClaimGetByUserIdResponseDto>();
            CreateMap<UserOperationClaimGetByUserIdResponseDto, UserOperationClaim>();
            
        }
    }
}
