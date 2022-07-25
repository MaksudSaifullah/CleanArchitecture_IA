using MediatR;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetByIdCreationValue;

public record GetByIdCreationQuery(int value,Guid countryId,int auditType):IRequest<GetByIdCreationValueDTO>;

