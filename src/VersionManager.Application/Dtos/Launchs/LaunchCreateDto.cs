
using VersionManager.Domain.Entities;

namespace VersionManager.Application.Dtos.Launchs
{
    public sealed record LaunchCreateDto
    {
        public string Message { get; init; } = string.Empty;
        public IEnumerable<Contract> Contracts { get; init; } = [];
        public bool AllowedForAllContracts { get; init; } = true;
        public bool RequiredAcceptance { get; init; } = false;
    }
}
