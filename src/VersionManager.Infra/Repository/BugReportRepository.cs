using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VersionManager.Domain.Entities;
using VersionManager.Infra.Context;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Infra.Repository
{
    internal sealed class BugReportRepository(VersionContext context) : IBugReportRepository
    {
        private readonly VersionContext _context = context;
        public async Task<BugReport?> GetByIdAsync(Guid id, CancellationToken cl)
        {
            var bugReport = await _context.BugReport
                .FirstOrDefaultAsync(s => s.Id == id, cl);

            return bugReport;
        }

        public void Create(BugReport entity)
        {
            _context.BugReport.Add(entity);
        }
    }
}
