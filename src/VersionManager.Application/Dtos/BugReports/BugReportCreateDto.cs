using System.ComponentModel.DataAnnotations;

namespace VersionManager.Application.Dtos.BugReports
{
    public sealed record BugReportCreateDto
    {
        [Required(ErrorMessage = "Value content is required")]
        public string Content { get; init; } = string.Empty;
    }
}
