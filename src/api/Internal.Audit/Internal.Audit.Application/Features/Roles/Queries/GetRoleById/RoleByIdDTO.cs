
namespace Internal.Audit.Application.Features.Roles.Queries.GetRoleById;
public record RoleByIdDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}