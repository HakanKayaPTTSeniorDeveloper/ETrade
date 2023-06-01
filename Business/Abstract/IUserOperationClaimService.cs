using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimAddDtos;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimGetByIdDtos;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimGetByUserIdDtos;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimGetListDtos;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimUpdateDtos;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        Task<IDataResult<UserOperationClaimGetByIdResponseDto>> GetById(int id);
        Task<IDataResult<List<UserOperationClaimGetListResponseDto>>> GetList();
        Task<IResult> Add(UserOperationClaimAddRequestDto userOperationClaimAddRequestDto);
        Task<IResult> Update(UserOperationClaimUpdateRequestDto userOperationClaimUpdateRequestDto);
        Task<IResult> Delete(int id);
        Task<IDataResult<List<UserOperationClaimGetByUserIdResponseDto>>> GetByUserId(int userId);
    }
}
