using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.DocumentSources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.DocumentSources.Queries.GetAllDocumentSource
{
    public class GetAllDocumentSourceQueryHandler : IRequestHandler<GetAllDocumentSourceQuery, IEnumerable<GetAllDocumentSourceDTO>>
    {
        private readonly IDocumentSourceQueryRepository _docuementSourceQueryRepository;
        private readonly IMapper _mapper;
        public GetAllDocumentSourceQueryHandler(IDocumentSourceQueryRepository docuementSourceQueryRepository, IMapper mapper)
        {
            _docuementSourceQueryRepository = docuementSourceQueryRepository ?? throw new ArgumentNullException(nameof(docuementSourceQueryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<GetAllDocumentSourceDTO>> Handle(GetAllDocumentSourceQuery request, CancellationToken cancellationToken)
        {
            var documentSourceList = await _docuementSourceQueryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAllDocumentSourceDTO>>(documentSourceList);
        }
    }
}
