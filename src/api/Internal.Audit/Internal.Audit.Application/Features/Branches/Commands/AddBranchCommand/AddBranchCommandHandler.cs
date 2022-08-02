using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Branches;
using Internal.Audit.Domain.Entities.security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Branches.Commands.AddBranchCommand;

public class AddBranchCommandHandler : IRequestHandler<AddBranchCommand, AddBranchCommandDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBranchCommandRepository _branchRepository;
    private readonly IMapper _mapper;

    public AddBranchCommandHandler(IBranchCommandRepository branchRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _branchRepository = branchRepository ?? throw new ArgumentNullException(nameof(branchRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddBranchCommandDTO> Handle(AddBranchCommand request, CancellationToken cancellationToken)
    {
        var extsts =await _branchRepository.Get(x=>x.CountryId==request.CountryId && x.BranchCode==request.BranchCode);
        if (extsts.Count() == 0)
        {
            var branch = _mapper.Map<Branch>(request);
            var newbranch = await _branchRepository.Add(branch);
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new AddBranchCommandDTO(newbranch.Id, rowsAffected > 0, rowsAffected > 0 ? "Branch Added Successfully!" : "Error while creating Branch!");

        }
        return new AddBranchCommandDTO(Guid.NewGuid(), false, "Branch already exists!");

    }
}
