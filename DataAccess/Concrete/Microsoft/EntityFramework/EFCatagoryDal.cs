using Core.DataAccess.Concrete.EntityFramework;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.Microsoft.EntityFramework.Contexts;
using Entity.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Microsoft.EntityFramework
{
    public class EFCatagoryDal : EFEntityRepositoryBase<Category, ETradeContext>, ICategoryDal
    {
      
    }
}
