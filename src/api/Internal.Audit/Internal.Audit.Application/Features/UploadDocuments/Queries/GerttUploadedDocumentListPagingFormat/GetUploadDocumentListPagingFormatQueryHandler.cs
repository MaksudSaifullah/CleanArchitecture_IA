using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.UploadDocuments;
using Internal.Audit.Application.Features.UploadDocuments.Queries.GetUploadedDocumentListByRoled;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UploadDocuments.Queries.GerttUploadedDocumentListPagingFormat;

public class GetUploadDocumentListPagingFormatQueryHandler : IRequestHandler<GetUploadDocumentListPagingFormatQuery, GerttUploadedDocumentListPagingFormatDTO>
{
    private readonly IUploadDocumentQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetUploadDocumentListPagingFormatQueryHandler(IUploadDocumentQueryRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<GerttUploadedDocumentListPagingFormatDTO> Handle(GetUploadDocumentListPagingFormatQuery request, CancellationToken cancellationToken)
    {
        var listResult = await _repository.GetAllAsyncByRoleId(request.searchTerm.RoleId, request.pageSize, request.pageNumber);
        var items= _mapper.Map<IList<GetUploadedDocumentLstByRoleIdDTO>>(listResult);
        long count = items.Select(x=>x.TotalCount.Tc).FirstOrDefault();
        GerttUploadedDocumentListPagingFormatDTO result = new GerttUploadedDocumentListPagingFormatDTO
        {
            Items = items,
            TotalCount = count
        };
        return result;
    }
}
