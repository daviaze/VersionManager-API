using VersionManager.Domain.Entities;
using VersionManager.Domain.Enums;

namespace VersionManager.Application.Dtos.Contracts
{
    public sealed record ContractReadDto
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public IEnumerable<Customer> Customers { get; init; } = Enumerable.Empty<Customer>();
        public IEnumerable<VersionManager.Domain.Entities.System> Systems { get; init; } = [];
        public StatusContract Status { get; init; }
    }

}
