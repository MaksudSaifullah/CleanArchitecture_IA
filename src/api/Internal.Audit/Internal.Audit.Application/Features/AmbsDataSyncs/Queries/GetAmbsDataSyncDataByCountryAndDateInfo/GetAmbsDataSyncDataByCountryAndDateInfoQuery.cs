using MediatR;

namespace Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetAmbsDataSyncDataByCountryAndDateInfo;

public record GetAmbsDataSyncDataByCountryAndDateInfoQuery(DateTime? effectiveFrom, DateTime? effectiveTo,Guid? CountryId,int typeId,decimal conversionRate,int pageNumber,int pageSize):IRequest<IEnumerable<GetAmbsDataSyncDataByCountryAndDateInfoDTO>>;

