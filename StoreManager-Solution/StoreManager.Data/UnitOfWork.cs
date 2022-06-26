using Microsoft.EntityFrameworkCore;

namespace StoreManager.Data
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext) => _dbContext = dbContext;

        public async virtual ValueTask DisposeAsync() => _dbContext?.DisposeAsync();
        public async virtual Task SaveAsync() => await _dbContext?.SaveChangesAsync();
    }
}
