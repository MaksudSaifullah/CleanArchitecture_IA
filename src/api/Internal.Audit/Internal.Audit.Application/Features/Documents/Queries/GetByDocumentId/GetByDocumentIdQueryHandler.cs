using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Documents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Documents.Queries.GetByDocumentId
{
    public class GetByDocumentIdQueryHandler : IRequestHandler<GetByDocumentQuery, GetByDocumentIdResponseDTO>
    {
        private readonly IDocumentQueryRepository _documentQueryRepository;
        private readonly IMapper _mapper;
        public GetByDocumentIdQueryHandler(IDocumentQueryRepository documentQueryRepository, IMapper mapper)
        {
            _documentQueryRepository = documentQueryRepository ?? throw new ArgumentNullException(nameof(documentQueryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetByDocumentIdResponseDTO> Handle(GetByDocumentQuery request, CancellationToken cancellationToken)
        {
            var result =  await _documentQueryRepository.GetByDocumentId(request.id);
            return _mapper.Map<GetByDocumentIdResponseDTO>(result);
        }
    }
}
