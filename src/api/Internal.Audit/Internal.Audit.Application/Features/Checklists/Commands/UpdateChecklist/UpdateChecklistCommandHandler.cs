using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Checklists;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Checklists.Commands.UpdateChecklist;


public class UpdateChecklistCommandHandler : IRequestHandler<UpdateChecklistCommand, UpdateChecklistResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly IChecklistCommandRepository _checklistRepository;
    private readonly IChecklistTopicCommandRepository _checklistTopicRepository;
    private readonly IChecklistTopicDetailCommandRepository _checklistTopicDetailRepository;

    public UpdateChecklistCommandHandler(IChecklistCommandRepository checklistRepository, IMapper mapper, IUnitOfWork unitOfWork,
        IChecklistTopicCommandRepository checklistTopicRepository, IChecklistTopicDetailCommandRepository checklistTopicDetailRepository)
    {
        _checklistRepository = checklistRepository ?? throw new ArgumentNullException(nameof(checklistRepository));
        _checklistTopicRepository = checklistTopicRepository ?? throw new ArgumentNullException(nameof(checklistTopicRepository));
        _checklistTopicDetailRepository = checklistTopicDetailRepository ?? throw new ArgumentNullException(nameof(checklistTopicDetailRepository));
       
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<UpdateChecklistResponseDTO> Handle(UpdateChecklistCommand request, CancellationToken cancellationToken)
    {

        var checklist = await _checklistRepository.Get(request.Id);
        if (checklist == null)
            return new UpdateChecklistResponseDTO(request.Id, false, "Invalid Checklist");
        await _checklistTopicRepository.Delete(_checklistTopicRepository.Get(x => x.ChecklistId == request.Id).Result.ToList());
       
        var checklistTopicId = _checklistTopicRepository.Get(x => x.ChecklistId == request.Id).Result.ToList().FirstOrDefault()?.Id;
        var getDetailModel = await _checklistTopicDetailRepository.Get(x => x.ChecklistTopicId == checklistTopicId);
        await _checklistTopicDetailRepository.Delete(getDetailModel);
       
        var mixed = _mapper.Map(request, checklist);
        await _checklistRepository.Update(mixed);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new UpdateChecklistResponseDTO(request.Id, rowsAffected > 0, "Updated Checklist");

    }
}
