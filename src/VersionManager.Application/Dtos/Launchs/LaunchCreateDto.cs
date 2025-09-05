
using VersionManager.Domain.Entities;

namespace VersionManager.Application.Dtos.Launchs
{
    public sealed record LaunchCreateDto
    {
        public string Message { get; init; } = string.Empty;
        public IEnumerable<Guid> ContractIds { get; init; } = [];
        public bool AllowedForAllContracts { get; init; } = false;
        public bool RequiredAcceptance { get; init; } = false;
    }
}
