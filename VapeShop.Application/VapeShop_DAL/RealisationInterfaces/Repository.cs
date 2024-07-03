using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Application.VapeShop_DAL.Interfaces;
using VapeShop.Domain;

namespace VapeShop.Application.VapeShop_DAL.RealisationInterfaces
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {

        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<TEntity> AsReadOnlyQueryable()
        {
            return _dbSet.AsQueryable().AsNoTracking();
        }

        public TEntity Create(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return _dbSet.Update(entity).Entity;
        }
        

        public TEntity Delete(TEntity entity)
        {
            return _dbSet.Remove(entity).Entity;
        }
        public async Task<TEntity> InsertOrUpdate(
           Expression<Func<TEntity, bool>> predicate,
           TEntity entity
       )
        {
            var entityExists = await _dbSet.AnyAsync(predicate);
            if (entityExists)
            {
                return _dbSet.Update(entity).Entity;
            }

            return _dbSet.Add(entity).Entity;
        }
    }
}
