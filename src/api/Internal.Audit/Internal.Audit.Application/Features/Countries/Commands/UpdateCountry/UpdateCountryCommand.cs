using MediatR;

namespace Internal.Audit.Application.Features.Countries.Commands.UpdateCountry;

public class UpdateCountryCommand : IRequest<UpdateCountryResponseDTO>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Remarks { get; set; }
}

