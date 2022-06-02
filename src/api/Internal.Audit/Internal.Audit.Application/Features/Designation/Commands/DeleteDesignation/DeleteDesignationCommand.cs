using MediatR;

namespace Internal.Audit.Application.Features.Designation.Commands.DeleteDesignation;
public class DeleteDesignationCommand : IRequest<DeleteDesignationResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteDesignationCommand(Guid id)
    {
        Id = id;
    }
}

