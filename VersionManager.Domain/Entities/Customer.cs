
namespace VersionManager.Domain.Entities
{
    public sealed class Customer
    {
        public Guid Id { get; private init; }
        public string Name { get; private set; } = string.Empty;
        public string Document { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;

        public static Customer Create(string name, string document, string email)
        {
            return new Customer
            {
                Id = Guid.NewGuid(),
                Name = name,
                Document = document,
                Email = email
            };
        }
    }
}
