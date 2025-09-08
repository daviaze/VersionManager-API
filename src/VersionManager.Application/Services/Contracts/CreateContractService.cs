using FluentResults;
using VersionManager.Application.Dtos.Contracts;
using VersionManager.Application.Mappers;
using VersionManager.Application.Services.Interfaces;
using VersionManager.Domain.Entities;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Application.Services.Contracts
{
    public sealed class CreateContractService(IUnitOfWork unitOfWork) : IService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<ContractReadDto>> ExecuteAsync(ContractCreateDto dto,
            CancellationToken cancellationToken)
        {
            var resultContracts = await GetCustomersByIds(dto, cancellationToken);
            if (resultContracts.IsFailed)
                return Result.Fail(resultContracts.Errors);

            var entity = dto.MapToEntity(resultContracts.Value);
            _unitOfWork.ContractRepository.Create(entity);

            await _unitOfWork.Commit(cancellationToken);

            return Result.Ok<ContractReadDto>(entity.MapToReadDto());
        }

        private async Task<Result<IEnumerable<Customer>>> GetCustomersByIds(ContractCreateDto dto,
            CancellationToken cancellationToken)
        {
            var customers = await _unitOfWork.CustomerRepository
                    .GetByIdsAsync(dto.CustomerIds, cancellationToken);

            var differentIds = dto.CustomerIds.Except(customers.Select(c => c.Id)).ToList();
            if (differentIds.Count != 0)
                return Result.Fail(differentIds.Select(id => new Error($"Customer not found: {id}")));

            return Result.Ok(customers);
        }
    }
}
