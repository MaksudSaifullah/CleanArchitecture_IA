using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.EmailConfigs;
using Internal.Audit.Domain.CompositeEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailTypeList
{
    public class GetEmailTypeListQueryHandler : IRequestHandler<GetEmailTypeListQuery, EmailTypePagingDTO>
    {
        private readonly IEmailTypeQueryRepository _emailTypeQueryRepository;
        private readonly IMapper _mapper;
        public GetEmailTypeListQueryHandler(IEmailTypeQueryRepository emailTypeQueryRepository, IMapper mapper)
        {
            _emailTypeQueryRepository = emailTypeQueryRepository ?? throw new ArgumentNullException(nameof(emailTypeQueryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<EmailTypePagingDTO> Handle(GetEmailTypeListQuery request, CancellationToken cancellationToken)
        {
            var (count, result) = await _emailTypeQueryRepository.GetAll(request.pageSize, request.pageNumber);
            var emailConfigList = _mapper.Map<IEnumerable<EmailType>, IEnumerable<GetEmailTypeListResponseDTO>>(result).ToList();

            return new EmailTypePagingDTO { Items = emailConfigList, TotalCount = count };
        }
    }
}
