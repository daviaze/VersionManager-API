namespace VersionManager.Infra.Repository.Contracts.Generics
{
    public interface IDelete<T> where T : class
    {
        public Task DeleteAsync(T entity, CancellationToken cl);
    }
}
