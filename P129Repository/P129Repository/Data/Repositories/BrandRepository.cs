using Microsoft.EntityFrameworkCore;
using P129Repository.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P129Repository.Data.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
