using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailConfigList;
public class GetEmailConfigListQuery : IRequest<EmailConfigListPagingDTO>
{
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public CountrySearchTerm searchTerm { get; set; }
}
public class CountrySearchTerm
{
    public string countryName { get; set; }
}