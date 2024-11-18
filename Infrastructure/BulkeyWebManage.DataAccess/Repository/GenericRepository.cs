using BulkeyWebManage.DataAccess.DataAccess;
using BulkeyWebManage.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkeyWebManage.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        public readonly DbSet<T> _dbSet;
        public GenericRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _dbSet = _bookStoreDbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }


        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predication)
        {
            if (predication is null)
            {
                return await _bookStoreDbContext.Set<T>().ToListAsync();
            }
            else
            {
                return await _bookStoreDbContext.Set<T>().Where(predication).ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Entity not found");
            }
            return entity;
        }

        public async Task<T> Add(T entity)
        {
            var entry = await _dbSet.AddAsync(entity); // returns an EntityEntry<T>, which contains metadata about the entity, including its current state.
            return entry.Entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
