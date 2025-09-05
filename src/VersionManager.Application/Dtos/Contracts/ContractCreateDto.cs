using System.ComponentModel.DataAnnotations;
using VersionManager.Domain.Entities;

namespace VersionManager.Application.Dtos.Contracts
{
    public sealed record ContractCreateDto
    {
        [Required(ErrorMessage = "Value customers is required")]
        public IEnumerable<Guid> CustomerIds { get; init; } = [];

        [Required(ErrorMessage = "Value systems is required")]
        public IEnumerable<VersionManager.Domain.Entities.System> Systems { get; init; } = [];
    }
}
