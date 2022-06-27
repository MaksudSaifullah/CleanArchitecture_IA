using MediatR;

namespace Internal.Audit.Application.Features.Countries.Queries.GetCountryList;
public record GetCountryListQuery(int pageSize, int pageNumber) : IRequest<CountryListPagingDTO>;