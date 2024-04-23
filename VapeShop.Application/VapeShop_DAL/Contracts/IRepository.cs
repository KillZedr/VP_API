using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain;

namespace VapeShop.Application.VapeShop_DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity Create(TEntity entity);

        TEntity Delete(TEntity entity);

        IQueryable<TEntity> AsQueryable();

        IQueryable<TEntity> AsReadOnlyQueryable();

    }
}
