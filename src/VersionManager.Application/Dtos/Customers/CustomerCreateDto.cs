using System.ComponentModel.DataAnnotations;

namespace VersionManager.Application.Dtos.Customers
{
    public sealed record CustomerCreateDto
    {
        [Required(ErrorMessage = "Value name is required")]
        public string Name { get; init; } = string.Empty;

        [Required(ErrorMessage = "Value document is required")]
        public string Document { get; init; } = string.Empty;

        [Required(ErrorMessage = "Value email is required")]

        public string Email { get; init; } = string.Empty;
    }
}
