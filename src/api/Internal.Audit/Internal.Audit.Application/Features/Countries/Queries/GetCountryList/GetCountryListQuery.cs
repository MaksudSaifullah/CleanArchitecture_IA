using MediatR;

namespace Internal.Audit.Application.Features.Countries.Queries.GetCountryList;
public class GetCountryListQuery : IRequest<CountryListPagingDTO>
{
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public dynamic searchTerm { get; set; }
}