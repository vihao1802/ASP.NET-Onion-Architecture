using BulkeyWebManage.DataAccess.DataAccess;
using BulkeyWebManage.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkeyWebManage.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        public IGenreRepository Genres { get; private set; }
        public UnitOfWork(BookStoreDbContext bookStoreDbContext, IGenreRepository genreRepository)
        {
            _bookStoreDbContext = bookStoreDbContext;
            Genres = genreRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _bookStoreDbContext.SaveChangesAsync();
        }

    }
}
