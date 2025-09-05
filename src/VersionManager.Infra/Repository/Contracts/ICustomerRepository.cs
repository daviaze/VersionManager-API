

using VersionManager.Domain.Entities;
using VersionManager.Infra.Repository.Contracts.Generics;

namespace VersionManager.Infra.Repository.Contracts
{
    public interface ICustomerRepository : ICreate<Customer>, IGetById<Customer>
    {
        public Task<IEnumerable<Customer>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);
    }
}
