using MediatR;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetCommonValueTypeGeneric;

public record GetCommonValueTypeQuery(string type) : IRequest<List<GetCommonValueTypeGenericDTO>>;

