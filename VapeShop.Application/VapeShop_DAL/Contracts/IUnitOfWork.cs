using Microsoft.EntityFrameworkCore.Storage;
using VapeShop.Domain;

namespace VapeShop.Application.VapeShop_DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IDbContextTransaction BeginTransaction();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity; 
        Task<int> SaveShangesAsync();
    }
}
