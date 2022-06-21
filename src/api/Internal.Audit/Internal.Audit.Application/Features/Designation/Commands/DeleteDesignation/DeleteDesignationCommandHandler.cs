using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Designations;
using MediatR;

namespace Internal.Audit.Application.Features.Designation.Commands.DeleteDesignation;
public class DeleteDesignationCommandHandler : IRequestHandler<DeleteDesignationCommand, DeleteDesignationResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDesignationCommandRepository _designationRepository;
    private readonly IMapper _mapper;

    public DeleteDesignationCommandHandler(IUnitOfWork unitOfWork, IDesignationCommandRepository designationRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _designationRepository = designationRepository;
        _mapper = mapper;
    }
    public async Task<DeleteDesignationResponseDTO> Handle(DeleteDesignationCommand request, CancellationToken cancellationToken)
    {
        var designation = await _designationRepository.Get(request.Id);
        designation.IsDeleted = true;
        designation.IsActive = false;
        designation = _mapper.Map(request, designation);
        await _designationRepository.Update(designation);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteDesignationResponseDTO(designation.Id, rowsAffected > 0, rowsAffected > 0 ? "Designation Deleted Successfully!" : "Error while deleting designation!");
    }
}