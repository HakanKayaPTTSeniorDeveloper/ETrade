using Core.DataAccess.Concrete.EntityFramework;
using Core.Entity.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Microsoft.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Microsoft.EntityFramework
{
    public class EFUserOperationClaimDal : EFEntityRepositoryBase<UserOperationClaim, ETradeContext>, IUserOperationClaimDal
    {
        public async Task<IDataResult<List<OperationClaim>>> GetOperationClaimByUserId(int userId)
        {
            using (var context = new ETradeContext())
            {
                var result = (from uoc in context.UserOperationClaims
                              join oc in context.OperationClaims on uoc.OperationClaimId equals oc.Id
                              where uoc.UserId == userId
                              select oc).ToList();
                return new SuccessDataResult<List<OperationClaim>>(result);
            }
        }
    }
}
