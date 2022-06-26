using System.Linq.Expressions;

namespace StoreManager.Data
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        Task AddAsync(TEntity entity);
        Task RemoveAsync(TKey id);
        Task RemoveAsync(TEntity entityToDelete);
        Task RemoveAsync(Expression<Func<TEntity, bool>> filter);
        Task EditAsync(TEntity entityToUpdate);
        Task AddOrModify(TEntity entity, Expression<Func<TEntity, bool>> filter);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter,
            string includeProperties = "");
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task<(IList<TEntity> data, int total, int totalDisplay)> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10,
            bool isTrackingOff = false);

        Task<(IList<TEntity> data, int total, int totalDisplay)> GetDynamicAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10,
            bool isTrackingOff = false);

        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", bool isTrackingOff = false);

        Task<IList<TEntity>> GetDynamicAsync(Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            string includeProperties = "", bool isTrackingOff = false);
        Task<TEntity> GetByIncludeAsync(Expression<Func<TEntity, bool>> filter,
            string includeProperties = "");
    }
}
