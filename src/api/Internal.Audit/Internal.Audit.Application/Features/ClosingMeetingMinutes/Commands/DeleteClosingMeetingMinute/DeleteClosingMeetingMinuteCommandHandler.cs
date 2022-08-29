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
    private readonly IClosingMeetingPresentCommandRepository _closingMeetingPresentRepository;
    private readonly IClosingMeetingSubjectCommandRepository _closingMeetingSubjectRepository;
    private readonly IMapper _mapper;

    public DeleteClosingMeetingMinuteCommandHandler(IClosingMeetingMinutesCommandRepository closingMeetingMinutesRepository, IMapper mapper, IUnitOfWork unitOfWork,
        IClosingMeetingApologyCommandRepository closingMeetingApologyRepository, IClosingMeetingPresentCommandRepository closingMeetingPresentRepository, IClosingMeetingSubjectCommandRepository closingMeetingSubjectRepository)
    {
        _closingMeetingMinutesRepository = closingMeetingMinutesRepository ?? throw new ArgumentNullException(nameof(closingMeetingMinutesRepository));
        _closingMeetingPresentRepository = closingMeetingPresentRepository ?? throw new ArgumentNullException(nameof(closingMeetingPresentRepository));
        _closingMeetingApologyRepository = closingMeetingApologyRepository ?? throw new ArgumentNullException(nameof(closingMeetingApologyRepository));
        _closingMeetingSubjectRepository = closingMeetingSubjectRepository ?? throw new ArgumentNullException(nameof(closingMeetingSubjectRepository));

        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<DeleteClosingMeetingMinuteResponseDTO> Handle(DeleteClosingMeetingMinuteCommand request, CancellationToken cancellationToken)
    {
        /*var closingMeetingMinute = await _closingMeetingMinutesRepository.Get(request.userId);
        closingMeetingMinute.IsDeleted = true;
        await _closingMeetingMinutesRepository.Update(closingMeetingMinute);


        var closingMeetingPresentList = await _closingMeetingPresentRepository.GetAllUserCountryListByUserId(request.userId);
        foreach (var item in userCountryList)
        {
            item.IsDeleted = true;
        }
        await _userCountryRepository.Update(userCountryList);

        var userRoleList = await _userRoleQueryRepository.GetAllUserRoleListByUserId(request.userId);
        foreach (var item in userRoleList)
        {
            item.IsDeleted = true;
        }
        await _userRole.Update(userRoleList);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteUserRegistrationResponseDTO(request.userId, rowsAffected > 0, rowsAffected > 0 ? "User Deleted successfully!" : "Error while deleteing User!");*/

        var closingMeetingMinute = await _closingMeetingMinutesRepository.Get(request.Id);
        if (closingMeetingMinute == null)
            return new DeleteClosingMeetingMinuteResponseDTO(request.Id, false, "Invalid Meeting Minute Id");
        
        var mixed = _mapper.Map(request, closingMeetingMinute);
        mixed.IsDeleted = true;
        
        await _closingMeetingMinutesRepository.Update(mixed);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteClosingMeetingMinuteResponseDTO(request.Id, rowsAffected > 0, "Closing Meeting Minute deleted successfully");
    }
}