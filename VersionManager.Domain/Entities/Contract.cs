using VersionManager.Domain.Enums;

namespace VersionManager.Domain.Entities
{
    public sealed class Contract
    {
        public Guid Id { get; private init; }
        public int ExternalId { get; private init; }
        public DateTime CreatedAt { get; private init; }
        public DateTime? UpdatedAt { get; private set; }
        public ICollection<Customer> Customers { get; private set; } = [];
        public ICollection<System> Systems { get; private set; } = [];
        public StatusContract Status { get; private set; }

        public static Contract Create(ICollection<Customer> customers, ICollection<System> systems)
        {
            return new Contract
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Customers = customers,
                Systems = systems,
            };
        }

        public void Activate()
        {
            EnsureCanBeModified();
            Status = StatusContract.active;
        }

        public void Inactivate()
        {
            EnsureCanBeModified();
            Status = StatusContract.inactive;
        }

        public void Cancel()
        {
            EnsureCanBeModified();
            Status = StatusContract.canceled;
        }

        public void AddCustomer(Customer customer)
        {
            EnsureCanBeModified();
            Customers.Add(customer);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveCustomer(Guid id)
        {
            EnsureCanBeModified();
            var customer = Customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                Customers.Remove(customer);
                UpdatedAt = DateTime.UtcNow;
            }
        }

        public void AddSystem(System system)
        {
            EnsureCanBeModified();
            Systems.Add(system);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveSystem(Guid id)
        {
            EnsureCanBeModified();
            var system = Systems.FirstOrDefault(s => s.Id == id);
            if (system != null)
            {
                Systems.Remove(system);
                UpdatedAt = DateTime.UtcNow;
            }
        }

        private void EnsureCanBeModified()
        {
            if (Status == StatusContract.canceled)
                throw new InvalidOperationException("Cannot modify a canceled contract.");
        }
    }
}
