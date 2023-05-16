using Core.DataAccess.Abstract;
using Core.Entity.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal:IEntityRepositoryBase<UserOperationClaim>
    {
        Task<IDataResult<List<OperationClaim>>> GetOperationClaimByUserId(int userId);
    }
}
