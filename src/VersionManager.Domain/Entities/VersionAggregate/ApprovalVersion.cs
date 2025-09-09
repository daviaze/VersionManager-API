using VersionManager.Domain.Enums;

namespace VersionManager.Domain.Entities.VersionAggregate
{
    public sealed class ApprovalVersion : VersionBase
    {
        public override AmbientVersion AmbientVersion => AmbientVersion.approval;
        public static ApprovalVersion Create(Guid idSystem, string name, string description)
        {
            return new ApprovalVersion
            {
                Id = Guid.NewGuid(),
                SystemId = idSystem,
                Name = name,
                Description = description,
                CreatedAt = DateTime.UtcNow,
            };
        }
        public override void SendToRelease()
        {
            AmbientVersion = AmbientVersion.release;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
