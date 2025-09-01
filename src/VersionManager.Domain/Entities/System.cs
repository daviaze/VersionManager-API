
using VersionManager.Domain.Entities.VersionAggregate;

namespace VersionManager.Domain.Entities
{
    public sealed class System
    {
        public Guid Id { get; private init; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public ICollection<VersionBase> Versions { get; private set; } = [];
        public ICollection<Contract> Contracts { get; private set; } = [];

        public static System Create(string name, string description)
        {
            return new System
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description
            };
        }
    }
}
