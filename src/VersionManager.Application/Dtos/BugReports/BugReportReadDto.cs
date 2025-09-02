
namespace VersionManager.Application.Dtos.BugReports
{
    public sealed record BugReportReadDto(
        Guid Id,
        string Content,
        DateTime CreatedAt
    );
}
