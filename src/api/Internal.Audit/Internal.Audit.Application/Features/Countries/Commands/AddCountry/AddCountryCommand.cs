using MediatR;

namespace Internal.Audit.Application.Features.Countries.Commands.AddCountry;

public class AddCountryCommand : IRequest<AddCountryResponseDTO>
{   
    public string Name { get; set; }
    public string Code { get; set; }
    public string Remarks { get; set; }
}
