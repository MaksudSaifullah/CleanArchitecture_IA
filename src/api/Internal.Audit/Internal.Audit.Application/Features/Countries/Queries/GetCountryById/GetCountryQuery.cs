using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Countries.Queries.GetCountryById;
public record GetCountryQuery(Guid Id) : IRequest<CountryByIdDTO>;


