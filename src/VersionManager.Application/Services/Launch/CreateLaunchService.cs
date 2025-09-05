using FluentResults;
using VersionManager.Application.Dtos.Launchs;
using VersionManager.Application.Mappers;
using VersionManager.Application.Services.Interfaces;
using VersionManager.Domain.Entities;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Application.Services.Launch
{
    internal sealed class CreateLaunchService(IUnitOfWork unitOfWork) : IService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<LaunchReadDto>> ExecuteAsync(Guid idVersion, LaunchCreateDto dto, CancellationToken cancellationToken)
        {
            var version = await _unitOfWork.VersionRepository.GetByIdAsync(idVersion, cancellationToken);

            if(version is null)
                return Result.Fail("Version not found");

            IEnumerable<Contract> contracts = [];

            if (!dto.AllowedForAllContracts)
            {
                var resultContracts = await GetContractsByIds(dto, cancellationToken);
                if(resultContracts.IsFailed)
                    return Result.Fail(resultContracts.Errors);

                contracts = resultContracts.Value;
            }

            var entity = dto.MapToEntity(idVersion, contracts);

            _unitOfWork.LaunchRepository.Create(entity);
            await _unitOfWork.Commit(cancellationToken);

            return Result.Ok<LaunchReadDto>(entity.MapToReadDto());
        }

        private async Task<Result<IEnumerable<Contract>>> GetContractsByIds(LaunchCreateDto dto,
            CancellationToken cancellationToken)
        {
            var contracts = await _unitOfWork.ContractRepository
                    .GetByIdsAsync(dto.ContractIds, cancellationToken);

            var differentIds = dto.ContractIds.Except(contracts.Select(c => c.Id)).ToList();
            if (differentIds.Count != 0)
                return Result.Fail(differentIds.Select(id => new Error($"Contract not found: {id}")));

            return Result.Ok(contracts);
        }
    }
}
