using VersionManager.Infra.Context;
using VersionManager.Infra.Repository.Contracts;

namespace VersionManager.Infra.Repository
{
    internal sealed class UnitOfWork(VersionContext context) : IUnitOfWork
    {
        private readonly VersionContext _context = context;
        private IBugReportRepository? _bugReportRepository;
        private ISystemRepository? _systemRepository;
        private IVersionRepository? _versionRepository;
        private IContractRepository? _contractRepository;
        private ICustomerRepository? _customerRepository;
        private ILaunchRepository? _launchRepository;
        public IBugReportRepository BugReportRepository 
            => _bugReportRepository ??= new BugReportRepository(_context);
        public ISystemRepository SystemRepository 
            => _systemRepository ??= new SystemRepository(_context);
        public IVersionRepository VersionRepository 
            => _versionRepository ??= new VersionRepository(_context);
        public IContractRepository ContractRepository 
            => _contractRepository ??= new ContractRepository(_context);
        public ICustomerRepository CustomerRepository
            => _customerRepository ??= new CustomerRepository(_context);
        public ILaunchRepository LaunchRepository 
            => _launchRepository ??= new LaunchRepository(_context);

        public async Task Commit(CancellationToken cl)
        {
            await _context.SaveChangesAsync(cl);
        }
    }
}
