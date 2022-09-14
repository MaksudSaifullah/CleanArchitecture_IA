using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetCommonValueTypeGeneric;
using MediatR;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetRiskRatingInfo;

public record GetRiskRatingInfoQuery(Guid ImpactTypeId,Guid LikelihoodTypeId,DateTime Date):IRequest<GetCommonValueTypeGenericDTO>;

