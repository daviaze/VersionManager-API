using Microsoft.AspNetCore.Mvc;
using VersionManager.Application.Dtos.Customers;
using VersionManager.Application.Services.Customers;

namespace VersionManager.Controllers.Customers
{
    public sealed partial class CustomerController
    {
        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="service"></param>
        /// <param name="ct"></param>
        /// <returns>A created customer.</returns>
        /// <response code="201">Created customer with success.</response>
        /// <response code="400">Some validation erro occurred.</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerCreateDto dto,
            [FromServices] CreateCustomerService service, CancellationToken ct)
        {
            var result = await service.ExecuteAsync(dto, ct);
            return result.IsSuccess ? Created(string.Empty, result.Value) : BadRequest(result);
        }
    }
}
