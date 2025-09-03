using Riok.Mapperly.Abstractions;
using VersionManager.Application.Dtos.BugReports;
using VersionManager.Domain.Entities;

namespace VersionManager.Application.Mappers
{
    [Mapper]
    public static partial class BugReportMapper
    {
        [MapProperty(nameof(BugReport.Id), nameof(BugReportReadDto.Id))]
        [MapProperty(nameof(BugReport.Content), nameof(BugReportReadDto.Content))]
        [MapProperty(nameof(BugReport.CreatedAt), nameof(BugReportReadDto.CreatedAt))]
        [MapperIgnoreSource(nameof(BugReport.VersionId))]
        [MapperIgnoreSource(nameof(BugReport.Version))]
        public static partial BugReportReadDto MapToReadDto(this BugReport bug);
        public static BugReport MapToBugReport(this BugReportCreateDto bug)
            => BugReport.Create(bug.Content);
    }
}
