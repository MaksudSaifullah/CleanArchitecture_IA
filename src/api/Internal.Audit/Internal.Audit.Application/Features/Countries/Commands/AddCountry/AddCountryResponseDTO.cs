using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.Countries.Commands.AddCountry;

public record AddCountryResponseDTO : BaseResponseDTO
{
    public AddCountryResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}