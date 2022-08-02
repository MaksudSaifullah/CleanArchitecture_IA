using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Branches;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Branches.Commands.GetBranchList;

public class GetBranchListCommandHandler : IRequestHandler<GetBranchListCommnad, IEnumerable<GetBranchListResponseDTO>>
{
    private readonly IBranchCommandRepository _commandRepository;
    private readonly IMapper _mapper;

    public GetBranchListCommandHandler(IBranchCommandRepository commandRepository, IMapper mapper)
    {
        _commandRepository = commandRepository ?? throw new ArgumentNullException(nameof(commandRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<IEnumerable<GetBranchListResponseDTO>> Handle(GetBranchListCommnad request, CancellationToken cancellationToken)
    {
        var branchList =await _commandRepository.Get(x => x.CountryId == request.countyrId);
        return _mapper.Map<IEnumerable<GetBranchListResponseDTO>>(branchList);        
    }
}
