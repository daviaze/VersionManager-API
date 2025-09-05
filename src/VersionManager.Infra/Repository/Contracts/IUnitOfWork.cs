

namespace VersionManager.Infra.Repository.Contracts
{
    public interface IUnitOfWork
    {
        public IBugReportRepository BugReportRepository { get; }
        public ISystemRepository SystemRepository { get; }
        public IVersionRepository VersionRepository { get; }
        public IContractRepository ContractRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public ILaunchRepository LaunchRepository { get; }
        public Task Commit(CancellationToken cl);
    }
}
