using VersionManager.Domain.Entities;
using VersionManager.Domain.Enums;

namespace VersionManager.Application.Dtos.Versions
{
    public sealed record VersionReadDto(
        Guid Id,
        string Name,
        string Description,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        AmbientVersion AmbientVersion,
        Guid SystemId,
        bool HasBugs
        );
}
