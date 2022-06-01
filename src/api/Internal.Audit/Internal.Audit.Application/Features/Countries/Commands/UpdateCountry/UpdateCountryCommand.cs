using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Countries.Commands.UpdateCountry;

public class UpdateCountryCommand : IRequest<UpdateCountryResponseDTO>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Remarks { get; set; }
}

