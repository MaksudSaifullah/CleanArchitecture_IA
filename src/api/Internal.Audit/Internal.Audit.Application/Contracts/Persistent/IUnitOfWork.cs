
namespace Internal.Audit.Application.Contracts.Persistent;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
}
