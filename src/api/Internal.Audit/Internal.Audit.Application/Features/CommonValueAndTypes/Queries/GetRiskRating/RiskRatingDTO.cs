
namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetCountryById;
public record RiskRatingDTO
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string SubType { get; set; }
    public int Value { get; set; }
    public string Text { get; set; }
}