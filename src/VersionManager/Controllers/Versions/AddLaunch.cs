using Microsoft.AspNetCore.Mvc;
using VersionManager.Application.Dtos.Launchs;
using VersionManager.Application.Services.Launchs;

namespace VersionManager.Controllers.Versions
{
    public sealed partial class VersionController
    {
        /// <summary>
        /// Add a new launch to a version
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <param name="service"></param>
        /// <param name="ct"></param>
        /// <returns>A created launch.</returns>
        /// <response code="201">Created launch with success.</response>
        /// <response code="400">Some validation erro occurred.</response>
        [HttpPost("{id:guid}/launch")]
        public async Task<IActionResult> AddLaunch([FromRoute] Guid id, [FromBody] LaunchCreateDto dto,
            [FromServices] CreateLaunchService service, CancellationToken ct)
        {
            var result = await service.ExecuteAsync(id, dto, ct);

            return result.IsSuccess ? Created(string.Empty, result.Value) : NotFound(result);
        }
    }
}
