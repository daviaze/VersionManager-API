using FluentResults;
using VersionManager.Application.Dtos.Launchs;
using VersionManager.Application.Mappers;
using VersionManager.Application.Services.Interfaces;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Application.Services.Launchs
{
    public sealed class GetByIdLaunchService(IUnitOfWork unitOfWork) : IService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<LaunchReadDto>> ExecuteAsync(Guid idLaunch,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.LaunchRepository.GetByIdAsync(idLaunch, cancellationToken);

            if (entity is null)
                return Result.Fail("Launch not found");

            return Result.Ok<LaunchReadDto>(entity.MapToReadDto());
        }

    }
}
