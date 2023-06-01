using Core.Utilities.Results.Abstract;
using Core.Utilities.Security;
using Entities.Concrete.Dtos.AuthDtos.AccessTokenDtoS;
using Entities.Concrete.Dtos.AuthDtos.GetByUserNameDto;
using Entities.Concrete.Dtos.AuthDtos.LoginDtos;
using Entities.Concrete.Dtos.AuthDtos.RegisterDtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<AccessToken>> Register(RegisterRequestDto registerRequestDto);
        Task<IDataResult<AccessToken>> Login(LoginRequestDto loginRequestDto);
        Task<IResult> UserExists(string userName);
        Task<IDataResult<AccessToken>> CreateAccessToken(AccessTokenAddRequestDto accessTokenAddRequestDto);
        Task<IDataResult<GetByUserNameResponseDto>> GetByUserName(string userName);
    }
}
