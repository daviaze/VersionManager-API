using VersionManager.Domain.Enums;

namespace VersionManager.Domain.Entities.VersionAggregate
{
    public abstract class VersionBase
    {
        public Guid Id { get; protected init; }
        public string Name { get; protected init; } = string.Empty;
        public string Description { get; protected set; } = string.Empty;
        public DateTime CreatedAt { get; protected init; }
        public DateTime? UpdatedAt { get; protected set; }
        public virtual AmbientVersion AmbientVersion { get; protected set; }
        public Guid SystemId { get; protected init; }
        public System? System { get; protected set; }
        public List<BugReport> BugReports { get; protected set; } = [];

        public void AddReportBug(string description)
        {
            BugReports.Add(BugReport.Create(description));
        }
    }
}
