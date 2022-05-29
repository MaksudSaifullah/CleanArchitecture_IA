using Internal.Audit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.Countries;

public interface ICountryCommandRepository : IAsyncCommandRepository<Country>
{
}