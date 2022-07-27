using Microsoft.EntityFrameworkCore;
using P129Repository.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace P129Repository.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public async Task<bool> IsExist(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().AnyAsync(expression);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
