
using System.ComponentModel.DataAnnotations;

namespace VersionManager.Application.Dtos.Systems
{
    public sealed record SystemCreateDto
    {
        [Required(ErrorMessage = "Value name is required")]
        public string Name { get; init; } = string.Empty;

        [Required(ErrorMessage = "Value description is required")]
        public string Description { get; init; } = string.Empty;
    };
}
