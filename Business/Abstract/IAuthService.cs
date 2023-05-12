using Core.Utilities.Results.Abstract;
using Entity.Concrete.Dtos.AuthDtos.AuthLoginDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<AccessToken>> Login(LoginRequestDto loginRequestDto);
    }
}
