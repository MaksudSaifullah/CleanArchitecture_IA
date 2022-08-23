using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Branches;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Branches.Commands.GetBranchList;

public class GetBranchListCommandHandler : IRequestHandler<GetBranchListCommnad, GetBranchListResponseDTO>
{
    private readonly IBranchCommandRepository _commandRepository;
    private readonly IMapper _mapper;

    public GetBranchListCommandHandler(IBranchCommandRepository commandRepository, IMapper mapper)
    {
        _commandRepository = commandRepository ?? throw new ArgumentNullException(nameof(commandRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<GetBranchListResponseDTO> Handle(GetBranchListCommnad request, CancellationToken cancellationToken)
    {
       // var blist = await _commandRepository.Get(x => x.CountryId == request.countyrId,x=>x.);
        int skip = ((request.pageNumber - 1) * request.pageSize);
       // var branchList =await _commandRepository.GetWithInclude(x => x.CountryId == request.countyrId);
        var branchListGeneric =await _commandRepository.Get(x => x.CountryId == request.countyrId,x=>x.OrderByDescending(u=>u.BranchCode),x=>x.Country);
        var totalList = branchListGeneric.ToList().Count();
        var dataSet = branchListGeneric.Skip(skip).Take(request.pageSize);
        GetBranchListResponseDTO result = new GetBranchListResponseDTO
        {
            Items = _mapper.Map<IList<GetBranchListResponseDTORAW>>(dataSet),
            TotalCount = totalList 
        };
        return result; 
        
    }
}
