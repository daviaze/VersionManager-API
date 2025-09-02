
namespace VersionManager.Application.Dtos.Customers
{
    public sealed record CustomerReadDto(
        Guid Id,
        string Name,
        string Document,
        string Email);
}
