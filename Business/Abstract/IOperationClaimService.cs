using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimAddDtos;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimGetByIdDtos;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimGetListDtos;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimSearch;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimUpdateDtos;
using Entities.Concrete.Dtos.UserDtos.UserSearch;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        Task<IDataResult<OperationClaimGetByIdResponseDto>> GetById(int id);
        Task<IDataResult<List<OperationClaimGetListResponseDto>>> GetList();
        Task<IResult> Add(OperationClaimAddRequestDto operationClaimAddRequestDto);
        Task<IResult> Update(OperationClaimUpdateRequestDto operationClaimUpdateRequestDto);
        Task<IDataResult<List<OperationClaimSearchResponseDto>>> Search(OperationClaimSearchRequestDto operationClaimSearchRequestDto);
        Task<IResult> Delete(int id);
    }
}
