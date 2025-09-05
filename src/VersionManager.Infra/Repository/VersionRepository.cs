using Microsoft.EntityFrameworkCore;
using VersionManager.Domain.Entities.VersionAggregate;
using VersionManager.Infra.Context;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Infra.Repository
{
    internal sealed class VersionRepository(VersionContext context) : IVersionRepository
    {
        private readonly VersionContext _context = context;

        public void Create(VersionBase entity)
        {
            _context.Version.Add(entity);
        }

        public async Task<VersionBase?> GetByIdAsync(Guid id, CancellationToken cl)
        {
            var version = await _context.Version.FirstOrDefaultAsync(v => v.Id == id, cl);
            return version;
        }
    }
}
