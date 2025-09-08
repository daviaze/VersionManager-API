

namespace VersionManager.Domain.Exceptions
{
    public sealed class DomainOperationException(string message) : Exception(message);
}
