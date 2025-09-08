using Microsoft.AspNetCore.Mvc;
using VersionManager.Application.Dtos.BugReports;
using VersionManager.Application.Services.BugReports;

namespace VersionManager.Controllers.Versions
{
    public sealed partial class VersionController
    {
        /// <summary>
        /// Add a new bug report to a version
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <param name="service"></param>
        /// <param name="ct"></param>
        /// <returns>A created bug report.</returns>
        /// <response code="201">Created bug report with success.</response>
        /// <response code="400">Some validation erro occurred.</response>
        [HttpPost("{id:guid}/bug-report")]
        public async Task<IActionResult> AddBugReport([FromBody] BugReportCreateDto dto, [FromRoute] Guid id,
            [FromServices] CreateBugReportService service, CancellationToken ct)
        {
            var result = await service.ExecuteAsync(id, dto, ct);

            return result.IsSuccess ? Created(string.Empty, result.Value) : NotFound(result);
        }
    }
}
