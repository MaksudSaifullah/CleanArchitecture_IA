using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.DeleteClosingMeetingMinute;


public class DeleteClosingMeetingMinuteCommandHandler : IRequestHandler<DeleteClosingMeetingMinuteCommand, DeleteClosingMeetingMinuteResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClosingMeetingMinutesCommandRepository _closingMeetingMinutesRepository;
    private readonly IClosingMeetingApologyCommandRepository _closingMeetingApologyRepository;
    private readonly IClosingMeetingPresentCommandRepository _cMPCommandRepository;
    private readonly IClosingMeetingSubjectCommandRepository _closingMeetingSubjectRepository;

    private readonly IClosingMeetingPresentQueryRepository _closingMeetingPresentRepository;
    private readonly IClosingMeetingApologyQueryRepository _closingMeetingApologyQueryRepository;
    private readonly IClosingMeetingSubjectQueryRepository _closingMeetingSubjectQueryRepository;

    private readonly IMapper _mapper;

    public DeleteClosingMeetingMinuteCommandHandler(IClosingMeetingMinutesCommandRepository closingMeetingMinutesRepository, IMapper mapper, IUnitOfWork unitOfWork,
        IClosingMeetingApologyQueryRepository closingMeetingApologyQueryRepository, IClosingMeetingSubjectQueryRepository closingMeetingSubjectQueryRepository,
        IClosingMeetingPresentCommandRepository cMPCommandRepository, IClosingMeetingApologyCommandRepository closingMeetingApologyRepository, IClosingMeetingPresentQueryRepository closingMeetingPresentRepository, IClosingMeetingSubjectCommandRepository closingMeetingSubjectRepository)
    {
        _closingMeetingMinutesRepository = closingMeetingMinutesRepository ?? throw new ArgumentNullException(nameof(closingMeetingMinutesRepository));
        _closingMeetingPresentRepository = closingMeetingPresentRepository ?? throw new ArgumentNullException(nameof(closingMeetingPresentRepository));
        _closingMeetingApologyRepository = closingMeetingApologyRepository ?? throw new ArgumentNullException(nameof(closingMeetingApologyRepository));
        _closingMeetingSubjectRepository = closingMeetingSubjectRepository ?? throw new ArgumentNullException(nameof(closingMeetingSubjectRepository));
        
        _cMPCommandRepository = cMPCommandRepository ?? throw new ArgumentNullException(nameof(cMPCommandRepository));
        _closingMeetingApologyQueryRepository = closingMeetingApologyQueryRepository ?? throw new ArgumentNullException(nameof(closingMeetingApologyQueryRepository));
        _closingMeetingSubjectQueryRepository = closingMeetingSubjectQueryRepository ?? throw new ArgumentNullException(nameof(closingMeetingSubjectQueryRepository));
       
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<DeleteClosingMeetingMinuteResponseDTO> Handle(DeleteClosingMeetingMinuteCommand request, CancellationToken cancellationToken)
    {
        var closingMeetingMinute = await _closingMeetingMinutesRepository.Get(request.Id);
        closingMeetingMinute.IsDeleted = true;
        await _closingMeetingMinutesRepository.Update(closingMeetingMinute);


        var closingMeetingPresentList = await _closingMeetingPresentRepository.GetAllPresentListByCMMId(request.Id);
        foreach (var item in closingMeetingPresentList)
        {
            item.IsDeleted = true;
        }

        await _cMPCommandRepository.Update(closingMeetingPresentList);



        var closingMeetingApologyList = await _closingMeetingApologyQueryRepository.GetAllMeetingApologyListByMeetingMinutesId(request.Id);
        foreach (var item in closingMeetingApologyList)
        {
            item.IsDeleted = true;
        }

        await _closingMeetingApologyRepository.Update(closingMeetingApologyList);


        var closingMeetingSubjectList = await _closingMeetingSubjectQueryRepository.GetAllSubjectListByCMMId(request.Id);
        foreach (var item in closingMeetingSubjectList)
        {
            item.IsDeleted = true;
        }

        await _closingMeetingSubjectRepository.Update(closingMeetingSubjectList);


        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteClosingMeetingMinuteResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Closing Meeting Minute deleted successfully!" : "Error while deleteing Closing Meeting Minute!");

        /*var closingMeetingMinute = await _closingMeetingMinutesRepository.Get(request.Id);
        if (closingMeetingMinute == null)
            return new DeleteClosingMeetingMinuteResponseDTO(request.Id, false, "Invalid Meeting Minute Id");
        
        var mixed = _mapper.Map(request, closingMeetingMinute);
        mixed.IsDeleted = true;
        
        await _closingMeetingMinutesRepository.Update(mixed);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteClosingMeetingMinuteResponseDTO(request.Id, rowsAffected > 0, "Closing Meeting Minute deleted successfully");*/
    }
}