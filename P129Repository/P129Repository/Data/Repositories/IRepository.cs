using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace P129Repository.Data.Repositories
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<bool> IsExist(Expression<Func<TEntity, bool>> expression);
        void Remove(TEntity entity);
        Task<int> CommitAsync();
        int Commit();
    }
}
