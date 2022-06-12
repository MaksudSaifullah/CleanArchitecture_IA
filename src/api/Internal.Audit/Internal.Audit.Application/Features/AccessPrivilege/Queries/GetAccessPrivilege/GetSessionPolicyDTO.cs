
namespace Internal.Audit.Application.Features.AccessPrivilege.Queries.GetAccessPrivilege;
public record GetSessionPolicyDTO
{
    public Guid Id { get; set; }
    public bool IsEnabled { get; set; }
    public int Duration { get; set; }
}