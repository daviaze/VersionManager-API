using VersionManager.Domain.Entities;
using VersionManager.Domain.Enums;

namespace VersionManager.Application.Dtos.Contracts
{
    public sealed record ContractReadDto(
        int ExternalId,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        IEnumerable<Customer> Customers,
        IEnumerable<VersionManager.Domain.Entities.System> Systems,
        StatusContract Status);
}
