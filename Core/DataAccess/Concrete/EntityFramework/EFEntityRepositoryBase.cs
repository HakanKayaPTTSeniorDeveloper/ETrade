using Core.DataAccess.Abstract;
using Core.DataAccess.Contants.Messages;
using Core.Entity.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<IResult> Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var entryEntity = context.Entry(entity);
                entryEntity.State = EntityState.Added;
                context.SaveChanges();
                return new SuccessResult(EntityRepositoryMessages.Added);
            }
        }

        public async Task<IResult> Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var entryEntity = context.Entry(entity);
                entryEntity.State = EntityState.Deleted;
                context.SaveChanges();
                return new SuccessResult(EntityRepositoryMessages.Deleted);
            }
        }

        public async Task<IDataResult<TEntity>> Get(Expression<Func<TEntity, bool>> filter)
        {
            using(var context = new TContext())
            {
                var dataResult= context.Set<TEntity>().FirstOrDefault(filter);
                return new SuccessDataResult<TEntity>(dataResult);
            }
        }

        public async Task<IDataResult<List<TEntity>>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                var dataResults =filter ==null? context.Set<TEntity>().ToList():context.Set<TEntity>().Where(filter).ToList();
                return new SuccessDataResult<List<TEntity>>(dataResults);
            }
        }

        public async Task<IResult> Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var entryEntity = context.Entry(entity);
                entryEntity.State = EntityState.Modified;
                context.SaveChanges();
                return new SuccessResult(EntityRepositoryMessages.Updated);
            }
        }
    }
}
