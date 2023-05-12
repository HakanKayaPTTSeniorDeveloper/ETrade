using Core.Entity.Abstract;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        Task<IResult> Add(TEntity entity);
        Task<IResult> Update(TEntity entity);
        Task<IResult> Delete(TEntity entity);
        Task<IDataResult<TEntity>> Get(Expression<Func<TEntity, bool>> filter);
        Task<IDataResult<List<TEntity>>> GetList(Expression<Func<TEntity, bool>> filter = null);
    }
}
