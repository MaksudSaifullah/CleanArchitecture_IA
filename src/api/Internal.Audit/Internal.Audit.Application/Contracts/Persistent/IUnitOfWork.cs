
namespace Internal.Audit.Application.Contracts.Persistent;

public interface IUnitOfWork
{
    Task<int> CommitAsync();

    Task<(int,string)> CommitAsyncwithErrorMsg();
}
