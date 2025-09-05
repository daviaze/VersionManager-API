using Riok.Mapperly.Abstractions;
using VersionManager.Application.Dtos.Versions;
using VersionManager.Domain.Entities.VersionAggregate;

namespace VersionManager.Application.Mappers
{
    [Mapper]
    public static partial class VersionMapper
    {
        [MapProperty(nameof(VersionBase.Id), nameof(VersionReadDto.Id))]
        [MapProperty(nameof(VersionBase.Name), nameof(VersionReadDto.Name))]
        [MapProperty(nameof(VersionBase.Description), nameof(VersionReadDto.Description))]
        [MapProperty(nameof(VersionBase.AmbientVersion), nameof(VersionReadDto.AmbientVersion))]
        [MapProperty(nameof(VersionBase.SystemId), nameof(VersionReadDto.SystemId))]
        [MapProperty(nameof(VersionBase.HasBugs), nameof(VersionReadDto.HasBugs))]
        [MapperIgnoreSource(nameof(VersionBase.System))]
        [MapperIgnoreSource(nameof(VersionBase.Launchs))]
        [MapperIgnoreSource(nameof(VersionBase.BugReports))]
        public static partial VersionReadDto MapToReadDto(this VersionBase version);
        public static VersionBase MapToEntity(this VersionCreateDto version, Guid systemId)
            => ApprovalVersion.Create(systemId, version.Name, version.Description);
    }
}
