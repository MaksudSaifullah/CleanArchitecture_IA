using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.EmailConfigs;
using Internal.Audit.Domain.CompositeEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailConfigList
{
    public class GetEmailConfigListQueryHandler : IRequestHandler<GetEmailConfigListQuery, EmailConfigListPagingDTO>
    {
        private readonly IEmailConfigQueryRepository _emailConfigQueryRepository;
        private readonly IMapper _mapper;
        public GetEmailConfigListQueryHandler(IEmailConfigQueryRepository emailConfigQueryRepository, IMapper mapper)
        {
            _emailConfigQueryRepository = emailConfigQueryRepository ?? throw new ArgumentNullException(nameof(emailConfigQueryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmailConfigListPagingDTO> Handle(GetEmailConfigListQuery request, CancellationToken cancellationToken)
        {
            var (count, result) = await _emailConfigQueryRepository.GetAll(request.searchTerm.countryName, request.pageSize, request.pageNumber);
            var emailConfigList = _mapper.Map<IEnumerable<CompositEmailConfig>,IEnumerable<GetEmailConfigListResponseDTO>>(result).ToList();

            return new EmailConfigListPagingDTO { Items = emailConfigList, TotalCount = count };
        }
    }
}
