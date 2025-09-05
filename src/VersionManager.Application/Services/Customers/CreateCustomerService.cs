using FluentResults;
using VersionManager.Application.Dtos.Customers;
using VersionManager.Application.Mappers;
using VersionManager.Application.Services.Interfaces;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Application.Services.Customers
{
    internal sealed class CreateCustomerService(IUnitOfWork unitOfWork) : IService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<CustomerReadDto>> ExecuteAsync(CustomerCreateDto dto, CancellationToken cancellationToken)
        {
            var entity = dto.MapToEntity();
            _unitOfWork.CustomerRepository.Create(entity);

            await _unitOfWork.Commit(cancellationToken);

            return Result.Ok<CustomerReadDto>(entity.MapToReadDto());
        }
    }
}
