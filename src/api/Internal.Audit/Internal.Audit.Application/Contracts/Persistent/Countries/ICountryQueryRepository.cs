using Internal.Audit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.Countries;

public interface ICountryQueryRepository : IAsyncQueryRepository<Country>
{
    Task<IEnumerable<Country>> GetAll();
    Task<Country> GetById(Guid id);    
}
