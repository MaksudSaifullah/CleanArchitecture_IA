namespace Internal.Audit.Application.Features.AccessPrivilege.Commands.UpdateAccessPrivilege;
public class UpdateSessionPolicyCommandDTO
{
    public Guid Id { get; set; }
    public bool IsEnabled { get; set; }
    public int Duration { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }
}