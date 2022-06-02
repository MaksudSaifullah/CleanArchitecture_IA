using MediatR;

namespace Internal.Audit.Application.Features.Countries.Commands.DeleteCountry;
public class DeleteCountryCommand : IRequest<DeleteCountryResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteCountryCommand(Guid id)
    {
        Id = id;
    }
}
