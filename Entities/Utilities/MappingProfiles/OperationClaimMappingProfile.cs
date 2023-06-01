using AutoMapper;
using Core.Entities.Concrete.Entities;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimAddDtos;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimGetByIdDtos;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimGetListDtos;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimSearch;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimUpdateDtos;
using Entities.Concrete.Dtos.UserDtos.UserSearch;

namespace Business.Utilities.MappingProfiles
{
    public class OperationClaimMappingProfile:Profile
    {
        public OperationClaimMappingProfile()
        {
            CreateMap<OperationClaim, OperationClaimAddRequestDto>();
            CreateMap<OperationClaimAddRequestDto, OperationClaim>();

            CreateMap<OperationClaim, OperationClaimGetByIdResponseDto>();
            CreateMap<OperationClaimGetByIdResponseDto, OperationClaim>();

            CreateMap<OperationClaim, OperationClaimGetListResponseDto>();
            CreateMap<OperationClaimGetListResponseDto, OperationClaim>();

            CreateMap<OperationClaim, OperationClaimUpdateRequestDto>();
            CreateMap<OperationClaimUpdateRequestDto, OperationClaim>();

            CreateMap<OperationClaim, OperationClaimSearchRequestDto>();
            CreateMap<OperationClaimSearchRequestDto, OperationClaim>();

            CreateMap<OperationClaim, OperationClaimSearchResponseDto>();
            CreateMap<OperationClaimSearchResponseDto, OperationClaim>();
        }
    }
}
