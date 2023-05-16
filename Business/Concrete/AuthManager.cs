using Business.Abstract;
using Core.Entity.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security;
using Core.Utilities.Security.Abstract;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entity.Concrete.Dtos.AuthDtos.AuthLoginDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserDal _userDal;
        private ITokenHelper _tokenHelper;
        private IUserOperationClaimDal _userOperationClaimDal;
        public AuthManager(IUserDal userDal, IUserOperationClaimDal userOperationClaimDal, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _userOperationClaimDal = userOperationClaimDal;
            _tokenHelper = tokenHelper;
        }
        public async Task<IDataResult<AccessToken>> Login(LoginRequestDto loginRequestDto)
        {
            var userResult = await _userDal.Get(x => x.UserName == loginRequestDto.UserName);
            if (userResult.Success)
            {
                if (userResult.Data != null)
                {
                    bool verfyPasswordHash = HashinHelper.VerfyPasswordHash(loginRequestDto.Password, userResult.Data.PasswordSalt, userResult.Data.PasswordSalt);
                    if (verfyPasswordHash)
                    {
                        var user = userResult.Data;
                        var operationClaimDataResult = await _userOperationClaimDal.GetOperationClaimByUserId(user.Id);
                        if (operationClaimDataResult.Success)
                        {
                            if (operationClaimDataResult.Data != null)
                            {
                                var operationClaims = operationClaimDataResult.Data;
                               return await _tokenHelper.CreateAccessToken(user, operationClaims);
                            }
                        }

                    }
                }
            }

            return null;

        }
    }
}
