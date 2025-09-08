using Microsoft.AspNetCore.Mvc;
using VersionManager.Application.Dtos.Systems;
using VersionManager.Application.Services.Systems;

namespace VersionManager.Controllers.Systems
{
    public sealed partial class SystemController
    {
        /// <summary>
        /// Create a new system
        /// </summary>
        /// <param name="service"></param>
        /// <param name="dto"></param>
        /// <param name="ct"></param>
        /// <returns>A created system.</returns>
        /// <response code="201">Created system with success.</response>
        /// <response code="400">Some validation erro occurred.</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] CreateSystemService service,
            [FromBody] SystemCreateDto dto, CancellationToken ct)
        {
            var result = await service.ExecuteAsync(dto, ct);
            return result.IsSuccess ? Created(string.Empty, result.Value) : BadRequest(result);
        }
    }
}
