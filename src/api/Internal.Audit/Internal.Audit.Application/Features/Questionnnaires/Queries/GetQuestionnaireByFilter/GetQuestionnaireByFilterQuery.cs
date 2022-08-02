using MediatR;

namespace Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnaireByFilter;
public record GetQuestionnaireByFilterQuery(GetQuestionnaireFilterDTO Filter) : IRequest<IEnumerable<GetQuestionnaireByFilterResponseDTO>>
{

}

