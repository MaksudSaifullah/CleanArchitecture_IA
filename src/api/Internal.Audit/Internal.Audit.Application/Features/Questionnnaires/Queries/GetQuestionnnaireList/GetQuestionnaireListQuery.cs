using MediatR;


namespace Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnnaireList;
public class GetQuestionnaireListQuery : IRequest<GetQuestionnaireListPagingDTO>
{
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public dynamic searchTerm { get; set; }
}
