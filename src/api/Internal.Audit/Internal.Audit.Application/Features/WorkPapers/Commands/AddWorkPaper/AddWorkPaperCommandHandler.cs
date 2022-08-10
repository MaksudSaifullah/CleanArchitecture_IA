using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.WorkPapers;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WorkPapers.Commands.AddWorkPaper;

public class AddWorkPaperCommandHandler : IRequestHandler<AddWorkPaperCommand, AddWorkPaperResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWorkPaperCommandRepository _workPaperRepository;
    private readonly IMapper _mapper;

    public AddWorkPaperCommandHandler(IWorkPaperCommandRepository workPaperRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _workPaperRepository = workPaperRepository ?? throw new ArgumentNullException(nameof(workPaperRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddWorkPaperResponseDTO> Handle(AddWorkPaperCommand request, CancellationToken cancellationToken)
    {
        var workPaper = _mapper.Map<WorkPaper>(request);
        var newworkPaper = await _workPaperRepository.Add(workPaper);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddWorkPaperResponseDTO(newworkPaper.Id, rowsAffected > 0, rowsAffected > 0 ? "Work Paper Added Successfully!" : "Error while creating Work Paper !");
    }

}