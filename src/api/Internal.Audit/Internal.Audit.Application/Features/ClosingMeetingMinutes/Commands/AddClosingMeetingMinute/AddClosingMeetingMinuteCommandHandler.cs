using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.AddClosingMeetingMinute;


public class AddClosingMeetingMinuteCommandHandler : IRequestHandler<AddClosingMeetingMinuteCommand, AddClosingMeetingMinuteResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClosingMeetingMinutesCommandRepository _closingMeetingMinutesRepository;
    private readonly IClosingMeetingApologyCommandRepository _closingMeetingApologyRepository;
    private readonly IClosingMeetingPresentCommandRepository _closingMeetingPresentRepository;
    private readonly IClosingMeetingSubjectCommandRepository _closingMeetingSubjectRepository;
    private readonly IMapper _mapper;

    public AddClosingMeetingMinuteCommandHandler(IClosingMeetingMinutesCommandRepository closingMeetingMinutesRepository, IMapper mapper, IUnitOfWork unitOfWork,
        IClosingMeetingApologyCommandRepository closingMeetingApologyRepository, IClosingMeetingPresentCommandRepository closingMeetingPresentRepository , IClosingMeetingSubjectCommandRepository closingMeetingSubjectRepository)
    {
        _closingMeetingMinutesRepository = closingMeetingMinutesRepository ?? throw new ArgumentNullException(nameof(closingMeetingMinutesRepository));
        _closingMeetingPresentRepository = closingMeetingPresentRepository ?? throw new ArgumentNullException(nameof(closingMeetingPresentRepository));
        _closingMeetingApologyRepository = closingMeetingApologyRepository ?? throw new ArgumentNullException(nameof(closingMeetingApologyRepository));
        _closingMeetingSubjectRepository = closingMeetingSubjectRepository ?? throw new ArgumentNullException(nameof(closingMeetingSubjectRepository));
       
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddClosingMeetingMinuteResponseDTO> Handle(AddClosingMeetingMinuteCommand request, CancellationToken cancellationToken)
    {
        var gid = Guid.NewGuid();
        request.ClosingMeetingMinute.Id = gid;

        var closingMeetingMinute = _mapper.Map<ClosingMeetingMinute>(request.ClosingMeetingMinute);
        var closingMeetingMinuteAdd = await _closingMeetingMinutesRepository.Add(closingMeetingMinute);

        request.ClosingMeetingPresent.ForEach(i => i.ClosingMeetingMinutesId = gid);
        var closingMeetingPresent = _mapper.Map<List<ClosingMeetingPresent>>(request.ClosingMeetingPresent);
        await _closingMeetingPresentRepository.Add(closingMeetingPresent);

        request.ClosingMeetingApology.ForEach(i => i.ClosingMeetingMinutesId = gid);
        var closingMeetingApology = _mapper.Map<List<ClosingMeetingApology>>(request.ClosingMeetingApology);
        await _closingMeetingApologyRepository.Add(closingMeetingApology);

        request.ClosingMeetingSubject.ForEach(i => i.ClosingMeetingMinutesId = gid);
        var closingMeetingSubject = _mapper.Map<List<ClosingMeetingSubject>>(request.ClosingMeetingSubject);
        await _closingMeetingSubjectRepository.Add(closingMeetingSubject);



        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddClosingMeetingMinuteResponseDTO(closingMeetingMinuteAdd.Id, rowsAffected > 0, rowsAffected > 0 ? "Closing Meeting Minute Added Successfully!" : "Error while creating Closing Meeting Minute !");
    }

}
