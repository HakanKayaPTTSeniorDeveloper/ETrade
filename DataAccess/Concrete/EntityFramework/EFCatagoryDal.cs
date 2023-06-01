using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete.Entities;

namespace DataAccess.Concrete.Microsoft.EntityFramework
{
    public class EFCatagoryDal : EFEntityRepositoryBase<Category, ETradeContext>, ICategoryDal
    {
      
    }
}
