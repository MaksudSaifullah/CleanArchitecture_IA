using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.EmailConfigs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailConfigById;
public class GetEmailConfigQueryHandler : IRequestHandler<GetEmailConfigQuery, GetEmailConfigByIdResponseDTO>
{
    private readonly IEmailConfigQueryRepository _emailConfigQueryRepository;
    private readonly IMapper _mapper;
 
    public GetEmailConfigQueryHandler(IEmailConfigQueryRepository emailConfigQueryRepository, IMapper mapper)
    {
        _emailConfigQueryRepository = emailConfigQueryRepository ?? throw new ArgumentNullException(nameof(emailConfigQueryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<GetEmailConfigByIdResponseDTO> Handle(GetEmailConfigQuery request, CancellationToken cancellationToken)
    {
        var country = await _emailConfigQueryRepository.GetById(request.Id);
        return _mapper.Map<GetEmailConfigByIdResponseDTO>(country);
    }
}
