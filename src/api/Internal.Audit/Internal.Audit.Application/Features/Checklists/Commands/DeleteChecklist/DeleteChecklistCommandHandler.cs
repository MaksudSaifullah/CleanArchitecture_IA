using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Checklists;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Checklists.Commands.DeleteChecklist;


public class DeleteChecklistCommandHandler : IRequestHandler<DeleteChecklistCommand, DeleteChecklistResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly IChecklistCommandRepository _checklistRepository;
    private readonly IChecklistTopicCommandRepository _checklistTopicRepository;
    private readonly IChecklistTopicDetailCommandRepository _checklistTopicDetailRepository;

    private readonly IChecklistQueryRepository _checklistQueryRepository;
    private readonly IChecklistTopicQueryRepository _checklistTopicQueryRepository;
    private readonly IChecklistTopicDetailQueryRepository _checklistTopicDetailQueryRepository;

    public DeleteChecklistCommandHandler(IChecklistCommandRepository checklistRepository, IMapper mapper, IUnitOfWork unitOfWork,
        IChecklistTopicCommandRepository checklistTopicRepository, IChecklistTopicDetailCommandRepository checklistTopicDetailRepository,
        IChecklistQueryRepository checklistQueryRepository, IChecklistTopicQueryRepository checklistTopicQueryRepository, IChecklistTopicDetailQueryRepository checklistTopicDetailQueryRepository)
    {
        _checklistRepository = checklistRepository ?? throw new ArgumentNullException(nameof(checklistRepository));
        _checklistTopicRepository = checklistTopicRepository ?? throw new ArgumentNullException(nameof(checklistTopicRepository));
        _checklistTopicDetailRepository = checklistTopicDetailRepository ?? throw new ArgumentNullException(nameof(checklistTopicDetailRepository));

        _checklistQueryRepository = checklistQueryRepository ?? throw new ArgumentNullException(nameof(checklistQueryRepository));
        _checklistTopicQueryRepository = checklistTopicQueryRepository ?? throw new ArgumentNullException(nameof(checklistTopicQueryRepository));
        _checklistTopicDetailQueryRepository = checklistTopicDetailQueryRepository ?? throw new ArgumentNullException(nameof(checklistTopicDetailQueryRepository));

        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<DeleteChecklistResponseDTO> Handle(DeleteChecklistCommand request, CancellationToken cancellationToken)
    {

        var checklist = await _checklistRepository.Get(request.Id);
        checklist.IsDeleted = true;
        await _checklistRepository.Update(checklist);


        var checklistTopicList = await _checklistTopicQueryRepository.GetAllChecklistTopicByChecklistId(request.Id);
        List<string> topicID = new List<string>();
        foreach (var item in checklistTopicList)
        {
            item.IsDeleted = true;
            // topicID[0] = "";
            topicID.Add(item.Id.ToString());
        }

        await _checklistTopicRepository.Update(checklistTopicList);

        var checklistTopicDetailList = await _checklistTopicDetailRepository.Get(x =>  topicID.Contains(x.Id.ToString()));

       // var checklistTopicDetailList = await _checklistTopicDetailQueryRepository.GetAllChecklistTopicDetailByChecklistTopicId(request.Id);
        foreach (var item in checklistTopicDetailList)
        {
            item.IsDeleted = true;
        }

        await _checklistTopicDetailRepository.Update(checklistTopicDetailList);




        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteChecklistResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Checklist deleted successfully!" : "Error while deleteing Checklist!");

        /*var checklist = await _checklistRepository.Get(request.Id);
        if (checklist == null)
            return new DeleteChecklistResponseDTO(request.Id, false, "Invalid Meeting Minute Id");
        
        var mixed = _mapper.Map(request, checklist);
        mixed.IsDeleted = true;
        
        await _checklistTopicRepository.Update(mixed);
        var rowsAffected = await _unitOfWork.CommitAsync();
       return new DeleteChecklistResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Checklist deleted successfully!" : "Error while deleteing Checklist!");*/
    }
}