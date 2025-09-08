using Microsoft.AspNetCore.Mvc;
using VersionManager.Application.Services.Systems;

namespace VersionManager.Controllers.Systems
{
    public sealed partial class SystemController
    {
        /// <summary>
        /// Get a system by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        /// <param name="ct"></param>
        /// <returns>A system.</returns>
        /// <response code="200">A system by id.</response>
        /// <response code="404">System not found.</response>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id,
            [FromServices] GetByIdSystemService service, CancellationToken ct)
        {
            var result = await service.ExecuteAsync(id, ct);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result);
        }
    }
}
