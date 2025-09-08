using Microsoft.AspNetCore.Mvc;
using VersionManager.Application.Dtos.Contracts;
using VersionManager.Application.Services.Contracts;

namespace VersionManager.Controllers.Contracts
{
    public sealed partial class ContractController
    {
        /// <summary>
        /// Create a new contract
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="service"></param>
        /// <param name="ct"></param>
        /// <returns>A created contract.</returns>
        /// <response code="201">Created contract with success.</response>
        /// <response code="400">Some validation erro occurred.</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContractCreateDto dto,
            [FromServices] CreateContractService service, CancellationToken ct)
        {
            var result = await service.ExecuteAsync(dto, ct);
            return result.IsSuccess ? Created(string.Empty, result.Value) : BadRequest(result);
        }
    }
}
