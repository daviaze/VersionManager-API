using Riok.Mapperly.Abstractions;
using VersionManager.Application.Dtos.Systems;

namespace VersionManager.Application.Mappers
{
    [Mapper]
    public static partial class SystemMapper
    {
        [MapProperty(nameof(Domain.Entities.System.Id), nameof(SystemReadDto.Id))]
        [MapProperty(nameof(Domain.Entities.System.Name), nameof(SystemReadDto.Name))]
        [MapProperty(nameof(Domain.Entities.System.Description), nameof(SystemReadDto.Description))]
        [MapperIgnoreSource(nameof(Domain.Entities.System.Versions))]
        [MapperIgnoreSource(nameof(Domain.Entities.System.Contracts))]
        public static partial SystemReadDto MapToReadDto(this Domain.Entities.System system);
        public static Domain.Entities.System MapToSystem(this SystemCreateDto system)
            => Domain.Entities.System.Create(system.Name, system.Description);
    }
}
