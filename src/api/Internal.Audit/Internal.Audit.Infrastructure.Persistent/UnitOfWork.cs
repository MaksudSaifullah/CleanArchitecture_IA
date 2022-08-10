
using Internal.Audit.Application.Contracts.Persistent;

namespace Internal.Audit.Infrastructure.Persistent;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly InternalAuditContext _context;

    public UnitOfWork(InternalAuditContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<int> CommitAsync()
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var affectedRows = await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return affectedRows;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw ex.InnerException;
        }
        finally
        {
            await _context.Database.CanConnectAsync();
            await _context.DisposeAsync();
        }
    }
    public async Task<(int,string)> CommitAsyncwithErrorMsg()
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var affectedRows = await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return (affectedRows,"Success");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            //throw ex.InnerException;
            return (-1, ex.InnerException.Message.ToString());
        }
        finally
        {
            await _context.Database.CanConnectAsync();
            await _context.DisposeAsync();
        }
    }

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
