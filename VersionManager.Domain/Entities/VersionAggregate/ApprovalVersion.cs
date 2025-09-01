using VersionManager.Domain.Enums;

namespace VersionManager.Domain.Entities.VersionAggregate
{
    public sealed class ApprovalVersion : VersionBase
    {
        public override AmbientVersion AmbientVersion => AmbientVersion.approval;
        public static ApprovalVersion Create(Guid id, string name, string description)
        {
            return new ApprovalVersion
            {
                Id = id,
                Name = name,
                Description = description,
                CreatedAt = DateTime.UtcNow,
            };
        }
        public void SendToRelease()
        {
            AmbientVersion = AmbientVersion.release;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
