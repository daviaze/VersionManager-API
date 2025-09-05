using Microsoft.EntityFrameworkCore;
using VersionManager.Infra.Context;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Infra.Repository
{
    internal sealed class SystemRepository(VersionContext context) : ISystemRepository
    {
        private readonly VersionContext _context = context;
        public void Create(Domain.Entities.System entity)
        {
            _context.System.Add(entity);
        }

        public async Task<Domain.Entities.System?> GetByIdAsync(Guid id, CancellationToken cl)
        {
            var system = await _context.System.FirstOrDefaultAsync(s => s.Id == id, cl);

            return system;
        }
    }
}
