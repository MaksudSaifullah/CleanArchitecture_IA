namespace Internal.Audit.Application.Features.AccessPrivilege.Commands.AddAccessPrivilege;
public record AddSessionPolicyDTO
{
    public bool IsEnabled { get; set; }
    public int Duration { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }
}
