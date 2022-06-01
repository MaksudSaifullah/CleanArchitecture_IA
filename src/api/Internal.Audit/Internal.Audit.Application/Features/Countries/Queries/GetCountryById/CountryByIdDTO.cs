
namespace Internal.Audit.Application.Features.Countries.Queries.GetCountryById;
public record CountryByIdDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Remarks { get; set; }
    public DateTime CreatedOn { get; set; }
}