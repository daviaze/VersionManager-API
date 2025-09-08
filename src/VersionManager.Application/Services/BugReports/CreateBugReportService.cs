using FluentResults;
using VersionManager.Application.Dtos.BugReports;
using VersionManager.Application.Mappers;
using VersionManager.Application.Services.Interfaces;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Application.Services.BugReports
{
    public sealed class CreateBugReportService(IUnitOfWork unitOfWork) : IService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<BugReportReadDto>> ExecuteAsync(Guid versionId, BugReportCreateDto dto, CancellationToken cl)
        {
            var version = await _unitOfWork.VersionRepository.GetByIdAsync(versionId, cl);

            if (version is null)
                return Result.Fail("Version not found");

            var report = dto.MapToEntity(version.Id);

            _unitOfWork.BugReportRepository.Create(report);
            await _unitOfWork.Commit(cl);

            return Result.Ok<BugReportReadDto>(report.MapToReadDto());
        }
    }
}
