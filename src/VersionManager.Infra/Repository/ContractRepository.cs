using Microsoft.EntityFrameworkCore;
using VersionManager.Domain.Entities;
using VersionManager.Infra.Context;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Infra.Repository
{
    internal sealed class ContractRepository(VersionContext context) : IContractRepository
    {
        private readonly VersionContext _context = context;
        public void Create(Contract entity)
        {
            _context.Contract.Add(entity);
        }

        public async Task<Contract?> GetByIdAsync(Guid id, CancellationToken cl)
        {
            var contract = await _context.Contract.FirstOrDefaultAsync(x => x.Id == id, cl);

            return contract;
        }

        public async Task<IEnumerable<Contract>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            var contracts = await _context.Contract.Where(x => ids.Contains(x.Id)).ToListAsync(cancellationToken);
            return contracts;
        }
    }
}
