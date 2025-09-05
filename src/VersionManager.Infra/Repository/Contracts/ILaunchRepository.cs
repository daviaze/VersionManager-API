
using VersionManager.Domain.Entities;
using VersionManager.Infra.Repository.Contracts.Generics;

namespace VersionManager.Infra.Repository.Contracts
{
    public interface ILaunchRepository : ICreate<Launch>, IGetById<Launch>
    {
    }
}
