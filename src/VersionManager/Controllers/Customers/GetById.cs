using Microsoft.AspNetCore.Mvc;
using VersionManager.Application.Services.Customers;

namespace VersionManager.Controllers.Customers
{
    public sealed partial class CustomerController
    {
        /// <summary>
        /// Get a customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        /// <param name="ct"></param>
        /// <returns>A customer.</returns>
        /// <response code="200">A customer by id.</response>
        /// <response code="404">Customer not found.</response>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id,
            [FromServices] GetByIdCustomerService service, CancellationToken ct)
        {
            var result = await service.ExecuteAsync(id, ct);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result);
        }
    }
}
