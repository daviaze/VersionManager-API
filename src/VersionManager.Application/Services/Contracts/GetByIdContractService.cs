using FluentResults;
using VersionManager.Application.Dtos.Contracts;
using VersionManager.Application.Mappers;
using VersionManager.Application.Services.Interfaces;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Application.Services.Contracts
{
    internal sealed class GetByIdContractService(IUnitOfWork unitOfWork) : IService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<ContractReadDto>> ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ContractRepository.GetByIdAsync(id, cancellationToken);

            if (entity is null)
                return Result.Fail("Contract not found");

            return Result.Ok<ContractReadDto>(entity.MapToReadDto());
        }
    }
}
