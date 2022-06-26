namespace StoreManager.Data
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task SaveAsync();
    }
}
