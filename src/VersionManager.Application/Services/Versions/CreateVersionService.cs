using FluentResults;
using VersionManager.Application.Dtos.Versions;
using VersionManager.Application.Mappers;
using VersionManager.Application.Services.Interfaces;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Application.Services.Versions
{
    internal sealed class CreateVersionService(IUnitOfWork unitOfWork) : IService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        
        public async Task<Result<VersionReadDto>> ExecuteAsync(Guid id, VersionCreateDto dto,
            CancellationToken cancellationToken)
        {
            var system = await _unitOfWork.SystemRepository.GetByIdAsync(id, cancellationToken);

            if (system is null)
                return Result.Fail(new Error("System not found"));

            var entity = dto.MapToEntity(system.Id);
            _unitOfWork.VersionRepository.Create(entity);

            await _unitOfWork.Commit(cancellationToken);

            return Result.Ok(entity.MapToReadDto());
        }
    }
}
