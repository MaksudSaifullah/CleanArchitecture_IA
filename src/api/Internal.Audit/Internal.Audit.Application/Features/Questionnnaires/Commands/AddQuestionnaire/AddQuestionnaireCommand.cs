using MediatR;

namespace Internal.Audit.Application.Features.Questionnnaires.Commands.AddQuestionnaire;
public class AddQuestionnaireCommand : IRequest<AddQuestionnaireResponseDTO>
{
    public Guid TopicHeadId { get; set; }
    public string Question { get; set; } = null;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }    
    public bool? IsActive { get; set; }
}