using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Checklists;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Checklists.Commands.AddChecklist;

public class AddChecklistCommandHandler : IRequestHandler<AddChecklistCommand, AddChecklistResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly IChecklistCommandRepository _checklistRepository;
    private readonly IChecklistTopicCommandRepository _checklistTopicRepository;
    private readonly IChecklistTopicDetailCommandRepository _checklistTopicDetailRepository;

    public AddChecklistCommandHandler(IChecklistCommandRepository checklistRepository, IMapper mapper, IUnitOfWork unitOfWork,
        IChecklistTopicCommandRepository checklistTopicRepository, IChecklistTopicDetailCommandRepository checklistTopicDetailRepository)
    {
        _checklistRepository = checklistRepository ?? throw new ArgumentNullException(nameof(checklistRepository));
        _checklistTopicRepository = checklistTopicRepository ?? throw new ArgumentNullException(nameof(checklistTopicRepository));
        _checklistTopicDetailRepository = checklistTopicDetailRepository ?? throw new ArgumentNullException(nameof(checklistTopicDetailRepository));
      
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddChecklistResponseDTO> Handle(AddChecklistCommand request, CancellationToken cancellationToken)
    {
        //var gid = Guid.NewGuid();
        //request.Id = gid;

        var checklist = _mapper.Map<Checklist>(request);
        var checklistAdd = await _checklistRepository.Add(checklist);

        //request.ChecklistTopic.ForEach(i => i.ChecklistId = gid);
        //var checklistTopic = _mapper.Map<List<ChecklistTopic>>(request.ChecklistTopic);
        //await _checklistTopicRepository.Add(checklistTopic);

        //request.ChecklistTopic.FirstOrDefault()?.ChecklistTopicDetail.ForEach(i => i.ChecklistTopicId = gid);
        //var checklistTopicDetail = _mapper.Map<List<ChecklistTopicDetail>>(request.ChecklistTopic.FirstOrDefault()?.ChecklistTopicDetail);
        //await _checklistTopicDetailRepository.Add(checklistTopicDetail);



        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddChecklistResponseDTO(checklistAdd.Id, rowsAffected > 0, rowsAffected > 0 ? "Checklist Added Successfully!" : "Error while creating Checklist !");
    }

}
