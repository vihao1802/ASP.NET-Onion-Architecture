using BulkeyWebManage.DataAccess.DataAccess;
using BulkeyWebManage.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkeyWebManage.DataAccess.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {
        }
        public async Task<IEnumerable<Genre>> GetByName(string name)
        {
            return await _dbSet
                .Where(g => g.Name.Contains(name))
                .ToListAsync();
        }
    }
}
