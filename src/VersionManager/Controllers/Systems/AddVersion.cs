using Microsoft.AspNetCore.Mvc;
using VersionManager.Application.Dtos.Versions;
using VersionManager.Application.Services.Versions;

namespace VersionManager.Controllers.Systems
{
    public sealed partial class SystemController
    {
        /// <summary>
        /// Add a new version to a system
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <param name="service"></param>
        /// <param name="ct"></param>
        /// <returns>A created version.</returns>
        /// <response code="201">Created version with success.</response>
        /// <response code="400">Some validation erro occurred.</response>
        [HttpPost("{id:guid}/version")]
        public async Task<IActionResult> AddVersion([FromBody] VersionCreateDto dto, [FromRoute] Guid id,
            [FromServices] CreateVersionService service, CancellationToken ct)
        {
            var result = await service.ExecuteAsync(id, dto, ct);
            return result.IsSuccess ? Created(string.Empty, result.Value) : NotFound(result);
        }
    }
}
