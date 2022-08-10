using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Designations;
using MediatR;

namespace Internal.Audit.Application.Features.Designation.Commands.UpdateDesignation;
public class UpdateDesignationCommandHandler : IRequestHandler<UpdateDesignationCommand, UpdateDesignationResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDesignationCommandRepository _designationRepository;
    private readonly IMapper _mapper;

    public UpdateDesignationCommandHandler(IUnitOfWork unitOfWork, IDesignationCommandRepository designationRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _designationRepository = designationRepository ?? throw new ArgumentNullException(nameof(designationRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UpdateDesignationResponseDTO> Handle(UpdateDesignationCommand request, CancellationToken cancellationToken)
    {
        var designation = await _designationRepository.Get(request.Id);
        designation = _mapper.Map(request, designation);
        await _designationRepository.Update(designation);
        var rowsAffected = await _unitOfWork.CommitAsyncwithErrorMsg();
        if (rowsAffected.Item1 == -1)
        {
            return new UpdateDesignationResponseDTO(designation.Id, false, rowsAffected.Item2);
        }
        return new UpdateDesignationResponseDTO(designation.Id, rowsAffected.Item1 > 0, rowsAffected.Item1 > 0 ? "Designation Updated Successfully!" : "Error while updating Designation!");
    }
}