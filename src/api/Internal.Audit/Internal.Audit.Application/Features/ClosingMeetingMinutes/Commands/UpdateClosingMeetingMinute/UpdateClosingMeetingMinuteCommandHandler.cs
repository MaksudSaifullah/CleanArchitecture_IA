using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.UpdateClosingMeetingMinute;


public class UpdateClosingMeetingMinuteCommandHandler : IRequestHandler<UpdateClosingMeetingMinuteCommand, UpdateClosingMeetingMinuteResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClosingMeetingMinutesCommandRepository _closingMeetingMinutesRepository;
    private readonly IClosingMeetingApologyCommandRepository _closingMeetingApologyRepository;
    private readonly IClosingMeetingPresentCommandRepository _closingMeetingPresentRepository;
    private readonly IClosingMeetingSubjectCommandRepository _closingMeetingSubjectRepository;
    private readonly IMapper _mapper;

    public UpdateClosingMeetingMinuteCommandHandler(IClosingMeetingMinutesCommandRepository closingMeetingMinutesRepository, IMapper mapper, IUnitOfWork unitOfWork,
        IClosingMeetingApologyCommandRepository closingMeetingApologyRepository, IClosingMeetingPresentCommandRepository closingMeetingPresentRepository, IClosingMeetingSubjectCommandRepository closingMeetingSubjectRepository)
    {
        _closingMeetingMinutesRepository = closingMeetingMinutesRepository ?? throw new ArgumentNullException(nameof(closingMeetingMinutesRepository));
        _closingMeetingPresentRepository = closingMeetingPresentRepository ?? throw new ArgumentNullException(nameof(closingMeetingPresentRepository));
        _closingMeetingApologyRepository = closingMeetingApologyRepository ?? throw new ArgumentNullException(nameof(closingMeetingApologyRepository));
        _closingMeetingSubjectRepository = closingMeetingSubjectRepository ?? throw new ArgumentNullException(nameof(closingMeetingSubjectRepository));

        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<UpdateClosingMeetingMinuteResponseDTO> Handle(UpdateClosingMeetingMinuteCommand request, CancellationToken cancellationToken)
    {

        var closingMeetingMinute = await _closingMeetingMinutesRepository.Get(request.Id);
        if (closingMeetingMinute == null)
            return new UpdateClosingMeetingMinuteResponseDTO(request.Id, false, "Invalid Closing Meeting Minute");
        await _closingMeetingPresentRepository.Delete(_closingMeetingPresentRepository.Get(x => x.ClosingMeetingMinutesId == request.Id).Result.ToList());
        await _closingMeetingApologyRepository.Delete(_closingMeetingApologyRepository.Get(x => x.ClosingMeetingMinutesId == request.Id).Result.ToList());
        await _closingMeetingSubjectRepository.Delete(_closingMeetingSubjectRepository.Get(x => x.ClosingMeetingMinutesId == request.Id).Result.ToList());

        var mixed = _mapper.Map(request, closingMeetingMinute);
        await _closingMeetingMinutesRepository.Update(mixed);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new UpdateClosingMeetingMinuteResponseDTO(request.Id, rowsAffected > 0, "Updated audit schedule Id");

    }
}