using Internal.Audit.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserCountries.Commands.AddUserCountry
{
    public record AddUserCountryResponseDTO : BaseResponseDTO
    {
        public AddUserCountryResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
        {
        }
    }
}
