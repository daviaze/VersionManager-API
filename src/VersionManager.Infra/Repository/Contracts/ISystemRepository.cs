
namespace VersionManager.Infra.Repository.Contracts
{
    public interface ISystemRepository : Generics.ICreate<Domain.Entities.System>,
        Generics.IGetById<Domain.Entities.System>;
}
