

namespace Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnaireByFilter;
public record GetQuestionnaireFilterDTO
{
    public string FilterName { get; set; }
    public Guid FilterValue { get; set; }
}
