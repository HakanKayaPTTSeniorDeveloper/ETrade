using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserOperationClaimDal : EFEntityRepositoryBase<UserOperationClaim, ETradeContext>, IUserOperationClaimDal
    {
    }
}