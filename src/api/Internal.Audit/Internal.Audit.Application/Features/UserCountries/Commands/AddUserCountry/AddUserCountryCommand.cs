using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserCountries.Commands.AddUserCountry
{
    public class AddUserCountryCommand:IRequest<AddUserCountryResponseDTO>
    {
        public Guid CountryId { get; set; }
       
        public Guid UserId { get; set; }
    }
}
