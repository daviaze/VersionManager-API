using Microsoft.AspNetCore.Mvc;
using VersionManager.Application.Services.Launchs;

namespace VersionManager.Controllers.Launchs
{
    public sealed partial class LaunchController
    {
        /// <summary>
        /// Get a launch by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        /// <param name="ct"></param>
        /// <returns>A launch.</returns>
        /// <response code="200">A launch by id.</response>
        /// <response code="404">Launch not found.</response>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id,
            [FromServices] GetByIdLaunchService service, CancellationToken ct)
        {
            var result = await service.ExecuteAsync(id, ct);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result);
        }
    }
}
