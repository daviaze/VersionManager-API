namespace VersionManager.Infra.Repository.Contracts.Generics
{
    public interface ICreate<T> where T : class
    {
        public void Create(T entity);
    }
}
