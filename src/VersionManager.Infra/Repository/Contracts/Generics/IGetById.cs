namespace VersionManager.Infra.Repository.Contracts.Generics
{
    public interface IGetById<T> where T : class
    {
        public Task<T?> GetByIdAsync(Guid id, CancellationToken cl);
    }
}
