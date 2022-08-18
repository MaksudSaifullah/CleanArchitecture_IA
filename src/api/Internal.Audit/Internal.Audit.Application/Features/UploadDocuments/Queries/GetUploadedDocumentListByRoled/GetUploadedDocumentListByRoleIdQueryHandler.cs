using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.UploadDocuments;
using MediatR;

namespace Internal.Audit.Application.Features.UploadDocuments.Queries.GetUploadedDocumentListByRoled;

public class GetUploadedDocumentListByRoleIdQueryHandler : IRequestHandler<GetUploadedDocumentListByRoleIdQuery, IEnumerable<GetUploadedDocumentLstByRoleIdDTO>>
{
    private readonly IUploadDocumentQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetUploadedDocumentListByRoleIdQueryHandler(IUploadDocumentQueryRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<GetUploadedDocumentLstByRoleIdDTO>> Handle(GetUploadedDocumentListByRoleIdQuery request, CancellationToken cancellationToken)
    {
        var result =await _repository.GetAllAsyncByRoleId(request.RoleId);
        return _mapper.Map<IEnumerable<GetUploadedDocumentLstByRoleIdDTO>>(result);
    }
}
