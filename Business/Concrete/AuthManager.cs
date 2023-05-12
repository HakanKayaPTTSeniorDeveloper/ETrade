using Business.Abstract;
using Core.Entity.Concrete;
using Core.Utilities.Results.Abstract;
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
        public AuthManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<IDataResult<AccessToken>> Login(LoginRequestDto loginRequestDto)
        {
            var userResult = await _userDal.Get(x => x.UserName == loginRequestDto.UserName);
            if (userResult.Success)
            {
                if (userResult.Data != null)
                {
                    bool verfyPasswordHash = HashinHelper.VerfyPasswordHash(loginRequestDto.Password, userResult.Data.PasswordSalt, userResult.Data.PasswordSalt);
                    if(verfyPasswordHash)
                    {
                        ///Token dön
                    }
                }
            }

            return null;

        }
    }
}
