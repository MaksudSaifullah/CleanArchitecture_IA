﻿using MediatR;

namespace Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetAmbsDataSyncDataByCountryAndDateInfo;

public record GetAmbsDataSyncDataByCountryAndDateInfoQuery(DateTime? startDate, DateTime? endDate,Guid? CountryId,int typeId,decimal conversionRate,int pageNumber,int pageSize):IRequest<IEnumerable<GetAmbsDataSyncDataByCountryAndDateInfoDTO>>;

