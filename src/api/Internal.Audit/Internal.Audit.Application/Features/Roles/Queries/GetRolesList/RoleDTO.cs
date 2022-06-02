namespace Internal.Audit.Application.Features.Roles.Queries.GetRolesList;
public record RoleDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
}