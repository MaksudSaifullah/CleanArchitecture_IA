using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Countries.Queries.GetCountryList
{
    public record CountryListPagingDTO
    {
        public IEnumerable<CountryDTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}
