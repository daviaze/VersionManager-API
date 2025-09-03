using Riok.Mapperly.Abstractions;
using VersionManager.Application.Dtos.Launchs;
using VersionManager.Domain.Entities;

namespace VersionManager.Application.Mappers
{
    [Mapper]
    public static partial class LaunchMapper
    {
        [MapProperty(nameof(Launch.Id), nameof(LaunchReadDto.Id))]
        [MapProperty(nameof(Launch.Message), nameof(LaunchReadDto.Message))]
        [MapProperty(nameof(Launch.RequiredAcceptance), nameof(LaunchReadDto.RequiredAcceptance))]
        [MapProperty(nameof(Launch.AllowedForAllContracts), nameof(LaunchReadDto.AllowedForAllContracts))]
        [MapProperty(nameof(Launch.CreatedAt), nameof(LaunchReadDto.CreatedAt))]
        [MapProperty(nameof(Launch.UpdateAt), nameof(LaunchReadDto.UpdateAt))]
        [MapperIgnoreSource(nameof(Launch.Version))]
        [MapperIgnoreSource(nameof(Launch.Contracts))]
        public static partial LaunchReadDto MapToReadDto(this Launch launch);
        public static Launch MapToLaunch(this LaunchCreateDto launch, Guid idVersion)
            => Launch.Create(idVersion, [.. launch.Contracts], launch.Message,
                launch.AllowedForAllContracts, launch.RequiredAcceptance);
    }
}
