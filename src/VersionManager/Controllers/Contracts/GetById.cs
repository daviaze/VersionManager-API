using Microsoft.AspNetCore.Mvc;
using VersionManager.Application.Services.Contracts;

namespace VersionManager.Controllers.Contracts
{
    public sealed partial class  ContractController
    {
        /// <summary>
        /// Get a contract by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        /// <param name="ct"></param>
        /// <returns>A contract.</returns>
        /// <response code="200">A contract by id.</response>
        /// <response code="404">Contract not found.</response>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, [FromServices] GetByIdContractService service,
            CancellationToken ct)
        {
            var result = await service.ExecuteAsync(id, ct);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result);
        }
    }
}
