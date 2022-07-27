using Microsoft.EntityFrameworkCore;
using P129Repository.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace P129Repository.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        //public async Task AddAsync(Category category)
        //{
        //    await _context.Categories.AddAsync(category);
        //}

        //public async Task<List<Category>> GetAllAsync(Expression<Func<Category,bool>> expression)
        //{
        //    return await _context.Categories.Where(expression).ToListAsync();
        //}

        //public async Task<Category> GetAsync(Expression<Func<Category, bool>> expression)
        //{
        //    return await _context.Categories.FirstOrDefaultAsync(expression);
        //}

        //public async Task<bool> IsExist(Expression<Func<Category, bool>> expression)
        //{
        //    return await _context.Categories.AnyAsync(expression);
        //}

        //public void Remove(Category category)
        //{
        //    _context.Categories.Remove(category);
        //}

        //public async Task<int> CommitAsync()
        //{
        //    return await _context.SaveChangesAsync();
        //}
        //public int Commit()
        //{
        //    return _context.SaveChanges();
        //}
    }
}
