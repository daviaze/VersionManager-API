using Microsoft.AspNetCore.Mvc;
using VersionManager.Application.Services.Versions;

namespace VersionManager.Controllers.Versions
{
    public sealed partial class VersionController
    {
        /// <summary>
        /// Get a version by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        /// <param name="ct"></param>
        /// <returns>A version.</returns>
        /// <response code="200">A version by id.</response>
        /// <response code="404">Version not found.</response>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id,
            [FromServices] GetByIdVersionService service, CancellationToken ct)
        {
            var result = await service.ExecuteAsync(id, ct);

            return result.IsSuccess ? Ok(result.Value) : NotFound(result);
        }
    }
}
