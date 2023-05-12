using Core.DataAccess.Abstract;
using Core.Utilities.Results.Abstract;
using Entity.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepositoryBase<Category>
    {
    }
}
