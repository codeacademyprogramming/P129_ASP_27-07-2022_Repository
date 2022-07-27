using P129Repository.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P129Repository.Data.Repositories
{
    public class GenreRepository : Repository<Genre>,IGenreRepository
    {
        public GenreRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
