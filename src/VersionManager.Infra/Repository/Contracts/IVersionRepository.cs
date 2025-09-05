using VersionManager.Domain.Entities.VersionAggregate;
using VersionManager.Infra.Repository.Contracts.Generics;

namespace VersionManager.Infra.Repository.Contracts
{
    public interface IVersionRepository : ICreate<VersionBase>, IGetById<VersionBase>
    {
    }
}
