

using VersionManager.Domain.Entities.VersionAggregate;

namespace VersionManager.Domain.Entities
{
    public sealed class BugReport
    {
        public Guid Id { get; private init; }
        public string Content { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private init; }
        public Guid VersionId { get; private init; }
        public VersionBase? Version { get; private set; }

        public static BugReport Create(string content)
        {
            return new BugReport
            {
                Id = Guid.NewGuid(),
                Content = content,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
