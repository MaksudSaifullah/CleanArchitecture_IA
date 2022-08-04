using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.WorkPapers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WorkPapers.Commands.UpdateWorkPaper;

public class UpdateWorkPaperCommandHandler : IRequestHandler<UpdateWorkPaperCommand, UpdateWorkPaperResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWorkPaperCommandRepository _workPaperRepository;
    private readonly IMapper _mapper;

    public UpdateWorkPaperCommandHandler(IWorkPaperCommandRepository workPaperRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _workPaperRepository = workPaperRepository ?? throw new ArgumentNullException(nameof(workPaperRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateWorkPaperResponseDTO> Handle(UpdateWorkPaperCommand request, CancellationToken cancellationToken)
    {
        var workPaper = await _workPaperRepository.Get(request.Id);
        var mappedWorkPaper = _mapper.Map(request, workPaper);
        var updatedWorkPaper = await _workPaperRepository.Update(mappedWorkPaper);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateWorkPaperResponseDTO(updatedWorkPaper.Id, rowsAffected > 0, rowsAffected > 0 ? "Work Paper Updated Successfully!" : "Error while updating Work Paper!");
    }
}
