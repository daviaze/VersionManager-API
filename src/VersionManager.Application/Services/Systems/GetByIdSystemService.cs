using FluentResults;
using VersionManager.Application.Dtos.Systems;
using VersionManager.Application.Mappers;
using VersionManager.Application.Services.Interfaces;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Application.Services.Systems
{
    public sealed class GetByIdSystemService(IUnitOfWork unitOfWork) : IService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<SystemReadDto>> ExecuteAsync(Guid id,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SystemRepository.GetByIdAsync(id, cancellationToken);

            if (entity is null)
                return Result.Fail("System not found");

            return Result.Ok<SystemReadDto>(entity.MapToReadDto());
        }
    }
}
