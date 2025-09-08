using FluentResults;
using VersionManager.Application.Dtos.Versions;
using VersionManager.Application.Mappers;
using VersionManager.Application.Services.Interfaces;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Application.Services.Versions
{
    public sealed class GetByIdVersionService(IUnitOfWork unitOfWork) : IService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<VersionReadDto>> ExecuteAsync(Guid id,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.VersionRepository.GetByIdAsync(id, cancellationToken);

            if (entity is null)
                return Result.Fail("Version not found");

            return Result.Ok(entity.MapToReadDto());
        }
    }
}
