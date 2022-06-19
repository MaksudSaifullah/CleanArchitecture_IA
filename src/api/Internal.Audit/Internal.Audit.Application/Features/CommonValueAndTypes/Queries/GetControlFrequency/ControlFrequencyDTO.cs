
namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetControlFrequency;
public record ControlFrequencyDTO
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string SubType { get; set; }
    public int Value { get; set; }
    public string Text { get; set; }
}