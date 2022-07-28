using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnnaireList;

public record GetQuestionnaireListResponseDTO
{
    public Guid Id { get; set; }
    public string Country { get; set; } = null!;
    public string TopicHead { get; set; } = null!;
    public string Question { get; set; } = null!;    
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
}