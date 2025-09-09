using VersionManager.Domain.Constants;
using VersionManager.Domain.Enums;
using VersionManager.Domain.Exceptions;

namespace VersionManager.Domain.Entities.VersionAggregate
{
    public sealed class ReleaseVersion : VersionBase
    {
        public override AmbientVersion AmbientVersion => AmbientVersion.release;
        public static ReleaseVersion Create(Guid id, string name, string description)
        {
            return new ReleaseVersion
            {
                Id = id,
                Name = name,
                Description = description,
                CreatedAt = DateTime.UtcNow,
            };
        }

        public override void SendToRelease()
        {
            throw new DomainOperationException(CustomError.RELEASE_VERSION_SEND_TO_RELEASE);
        }
    }
}
