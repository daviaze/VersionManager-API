

namespace VersionManager.Application.Dtos.Launchs
{
    public sealed record LaunchReadDto(Guid Id, string Message, Guid VersionId,
        bool AllowedForAllContracts, bool RequiredAcceptance, DateTime CreatedAt, DateTime? UpdateAt);
}
