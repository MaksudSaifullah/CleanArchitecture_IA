using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.Countries.Commands.UpdateCountry;
public record UpdateCountryResponseDTO : BaseResponseDTO
{
    public UpdateCountryResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}