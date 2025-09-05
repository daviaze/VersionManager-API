using Microsoft.EntityFrameworkCore;
using VersionManager.Domain.Entities;
using VersionManager.Infra.Context;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Infra.Repository
{
    internal sealed class CustomerRepository(VersionContext context) : ICustomerRepository
    {
        private readonly VersionContext _context = context;
        public void Create(Customer entity)
        {
            _context.Customer.Add(entity);
        }

        public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cl)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(s => s.Id == id, cl);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            var customers = await _context.Customer.Where(x => ids.Contains(x.Id)).ToListAsync(cancellationToken);
            return customers;
        }
    }
}
