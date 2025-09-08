using FluentResults;
using VersionManager.Application.Dtos.Customers;
using VersionManager.Application.Mappers;
using VersionManager.Application.Services.Interfaces;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Application.Services.Customers
{
    public sealed class GetByIdCustomerService(IUnitOfWork unitOfWork) : IService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<CustomerReadDto>> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.CustomerRepository.GetByIdAsync(id, cancellationToken);

            if (entity is null)
                return Result.Fail("Customer not found");

            return Result.Ok<CustomerReadDto>(entity.MapToReadDto());
        }
    }
}
