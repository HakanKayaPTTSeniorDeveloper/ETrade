using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Dtos.UserDtos.UserSearch;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserDal : EFEntityRepositoryBase<User, ETradeContext>, IUserDal
    {
        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            using (var context = new ETradeContext())
            {
                var result = (from uoc in context.UserOperationClaims
                              join oc in context.OperationClaims on uoc.OperationClaimId equals oc.Id
                              where uoc.UserId == user.Id && uoc.IsActive == true && oc.IsActive == true && user.IsActive == true
                              select new OperationClaim
                              {
                                  Id = oc.Id,
                                  Name = oc.Name
                              }).AsNoTracking();

                return result.ToList();
            }
        }

    }
}

