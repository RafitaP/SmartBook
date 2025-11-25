using Microsoft.EntityFrameworkCore;
using SmartBook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartBook.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _db;
        protected readonly DbSet<T> _set;

        public Repository(DbContext db)
        {
            _db = db;
            _set = db.Set<T>();
        }

        public virtual async Task AddAsync(T entity) => await _set.AddAsync(entity);

        public virtual async Task<T?> GetByIdAsync(object id) =>
            await _set.FindAsync(id) as T;

        public virtual async Task<IEnumerable<T>> ListAsync() =>
            await _set.ToListAsync();

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
            await _set.Where(predicate).ToListAsync();

        public virtual void Update(T entity) => _set.Update(entity);

        public virtual void Remove(T entity) => _set.Remove(entity);
    }
}
