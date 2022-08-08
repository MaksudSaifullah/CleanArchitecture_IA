using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.WorkPapers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WorkPapers.Commands.DeleteWorkPaper;

public class DeleteWorkPaperCommandHandler : IRequestHandler<DeleteWorkPaperCommand, DeleteWorkPaperResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWorkPaperCommandRepository _WorkPaperRepository;
    private readonly IMapper _mapper;

    public DeleteWorkPaperCommandHandler(IWorkPaperCommandRepository WorkPaperRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _WorkPaperRepository = WorkPaperRepository ?? throw new ArgumentNullException(nameof(WorkPaperRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<DeleteWorkPaperResponseDTO> Handle(DeleteWorkPaperCommand request, CancellationToken cancellationToken)
    {
        var WorkPaper = await _WorkPaperRepository.Get(request.Id);
        WorkPaper.IsDeleted = true;
        var mappedWorkPaper = _mapper.Map(request, WorkPaper);
        await _WorkPaperRepository.Update(mappedWorkPaper);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteWorkPaperResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Work Paper Deleted Successfully!" : "Error while deleting Work Paper!");
    }
}