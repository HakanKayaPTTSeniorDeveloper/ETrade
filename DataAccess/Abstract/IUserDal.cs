using Core.DataAccess.Abstract;
using Core.Entities.Concrete.Entities;
using Entities.Concrete.Dtos.UserDtos.UserSearch;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        Task<List<OperationClaim>> GetClaims(User user);
    }
}
