//using AutoMapper;
//using Internal.Audit.Application.Contracts.Persistent.Questionnnaires;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnnaireList;
//public class GetQuestionnaireListQueryHandler : IRequestHandler<GetQuestionnaireListQuery, GetQuestionnaireListPagingDTO>
//{
//    private readonly IQuestionnaireQueryRepository _repository;
//    private readonly IMapper _mapper;

//    public GetQuestionnaireListQueryHandler(IQuestionnaireQueryRepository repository, IMapper mapper)
//    {
//        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
//        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
//    }


//    public async Task<GetQuestionnaireListPagingDTO> Handle(GetQuestionnaireListQuery request, CancellationToken cancellationToken)
//    {
//        (long, IEnumerable<CompositeQuestionnaire>) result = await _repository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);

//        var questionnaires = _mapper.Map<List<GetQuestionnaireListResponseDTO>>(result.Item2);

//        return new GetQuestionnaireListPagingDTO { Items = questionnaires, TotalCount = result.Item1 };
//    }
//}