using VersionManager.Domain.Enums;
using VersionManager.Domain.Exceptions;

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
        public ICollection<BugReport> BugReports { get; protected set; } = [];
        public ICollection<Launch> Launchs { get; protected set; } = [];
        public bool HasBugs => BugReports.Count != 0;

        public BugReport AddReportBug(BugReport bugReport)
        {
            BugReports.Add(bugReport);
            return bugReport;
        }

        public virtual void SendToRelease()
        {
            throw new DomainOperationException("This method should be implemented in derived classes.");
        }
    }
}
