using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.UserDtos.UserAddDtos;
using Entities.Concrete.Dtos.UserDtos.UserGetByIdDtos;
using Entities.Concrete.Dtos.UserDtos.UserGetByUserNameDtos;
using Entities.Concrete.Dtos.UserDtos.UserGetClaimsDtos;
using Entities.Concrete.Dtos.UserDtos.UserSearch;
using Entities.Concrete.Dtos.UserDtos.UserUpdateDtos;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<UserGetClaimsResponseDto>>> GetClaims(UserGetClaimsRequestDto userGetClaimsRequestDto);
        Task<IResult> Add(UserAddRequestDto userAddRequestDto);
        Task<IDataResult<UserGetByUserNameResponseDto>> GetByUserName(string userName);
        Task<IResult> Update(UserUpdateRequestDto userUpdateRequestDto);
        Task<IResult> Delete(int id);
        Task<IDataResult<List<UserSearchResponseDto>>> Search(UserSearchRequestDto userSearchRequestDto);
        Task<IDataResult<UserGetByIdResponseDto>> GetById(int id);
    }
}
