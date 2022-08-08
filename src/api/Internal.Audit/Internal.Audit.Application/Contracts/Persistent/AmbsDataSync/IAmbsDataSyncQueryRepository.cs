namespace Internal.Audit.Application.Contracts.Persistent.AmbsDataSync;

public interface IAmbsDataSyncQueryRepository:IAsyncQueryRepository<Domain.Entities.security.AmbsDataSync>
{
    Task<IEnumerable<Domain.Entities.security.AmbsDataSync>> GetDataSyncList(Guid? countryId,DateTime? FromDate, DateTime? ToDate,int typeId,decimal conversionRate,int pageNumber,int pageSize);
}
