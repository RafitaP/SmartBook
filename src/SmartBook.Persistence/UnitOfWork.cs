using SmartBook.Application.Interfaces;
using SmartBook.Persistence.DbContext;
using System.Threading.Tasks;

namespace SmartBook.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmartBookDbContext _db;
        public UnitOfWork(SmartBookDbContext db) { _db = db; }
        public async Task<int> CommitAsync() => await _db.SaveChangesAsync();
    }
}