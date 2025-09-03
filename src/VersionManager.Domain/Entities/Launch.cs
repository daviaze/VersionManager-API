using VersionManager.Domain.Entities.VersionAggregate;

namespace VersionManager.Domain.Entities
{
    public sealed class Launch
    {
        public Guid Id { get; private init; }
        public string Message { get; private init; } = string.Empty;
        public VersionBase? Version { get; private init; }
        public Guid? VersionId { get; private init; }
        public ICollection<Contract> Contracts { get; private set; } = [];
        public bool AllowedForAllContracts { get; private set; }
        public bool RequiredAcceptance { get; private set; }
        public DateTime CreatedAt { get; private init; }
        public DateTime? UpdateAt { get; private set; }

        public static Launch Create(Guid versionId, ICollection<Contract> contracts,
            string message = "", bool allowedForAllContracts = false, bool requiredAcceptance = false)
        {
            if(!allowedForAllContracts && contracts.Count == 0)
            {
                throw new ArgumentException("Contracts must be provided if not allowed for all contracts.");
            }

            return new Launch
            {
                Id = Guid.NewGuid(),
                VersionId = versionId,
                Contracts = !allowedForAllContracts ? contracts : [],
                CreatedAt = DateTime.UtcNow,
                Message = message,
                AllowedForAllContracts = allowedForAllContracts,
                RequiredAcceptance = requiredAcceptance
            };
        }

        public void AddContract(Contract contract)
        {
            Contracts.Add(contract);
            UpdateAt = DateTime.UtcNow;
        }
    }
}
