
using System.ComponentModel.DataAnnotations;

namespace VersionManager.Application.Dtos.Systems
{
    public sealed record SystemCreateDto(string Name, string Description)
    {
        [Required(ErrorMessage = "Value name is required")]
        public string Name { get; init; } = Name;

        [Required(ErrorMessage = "Value description is required")]
        public string Description { get; init; } = Description;
    };
}
