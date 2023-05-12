using Core.Entity.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Microsoft.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EFUserDal:EFEntityRepositoryBase<User,ETradeContext>,IUserDal
    {
    }
}
