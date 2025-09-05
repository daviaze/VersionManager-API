using VersionManager.Domain.Entities;
using VersionManager.Infra.Repository.Contracts.Generics;

namespace VersionManager.Infra.Repository.Contracts
{
    public interface IContractRepository : ICreate<Contract>, IGetById<Contract>
    {
        public Task<IEnumerable<Contract>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);
    }
}
