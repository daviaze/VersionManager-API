using FluentResults;
using VersionManager.Application.Dtos.Systems;
using VersionManager.Application.Mappers;
using VersionManager.Application.Services.Interfaces;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Application.Services.Systems
{
    public sealed class CreateSystemService(IUnitOfWork unitOfWork) : IService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<SystemReadDto>> ExecuteAsync(SystemCreateDto dto,
            CancellationToken cancellationToken)
        {
            var entity = dto.MapToEntity();
            _unitOfWork.SystemRepository.Create(entity);

            await _unitOfWork.Commit(cancellationToken);

            return Result.Ok(entity.MapToReadDto());
        }
    }
}
