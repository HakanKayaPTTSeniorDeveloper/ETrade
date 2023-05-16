using Core.Entity.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Abstract
{
    public interface ITokenHelper
    {
       Task<IDataResult< AccessToken>> CreateAccessToken(User user, List<OperationClaim> operationClaims);
    }
}
