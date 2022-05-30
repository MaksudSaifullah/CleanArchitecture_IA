using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Countries.Commands.DeleteCountry;
public class DeleteCountryCommand : IRequest<DeleteCountryResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteCountryCommand(Guid id)
    {
        Id = id;
    }
}
