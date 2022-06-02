using MediatR;
namespace Internal.Audit.Application.Features.Designation.Commands.UpdateDesignation;
public class UpdateDesignationCommand: IRequest<UpdateDesignationResponseDTO>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}