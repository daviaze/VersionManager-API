using Microsoft.EntityFrameworkCore;
using VersionManager.Domain.Entities;
using VersionManager.Infra.Context;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Infra.Repository
{
    internal sealed class LaunchRepository(VersionContext context) : ILaunchRepository
    {
        private readonly VersionContext _context = context;
        public void Create(Launch entity)
        {
            _context.Launch.Add(entity);
        }

        public async Task<Launch?> GetByIdAsync(Guid id, CancellationToken cl)
        {
            var launch = await _context.Launch.FirstOrDefaultAsync(s => s.Id == id, cl);
            return launch;
        }
    }
}
