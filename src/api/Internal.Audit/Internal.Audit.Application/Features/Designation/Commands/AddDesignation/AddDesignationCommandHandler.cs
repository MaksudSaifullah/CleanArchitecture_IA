using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Designations;
using MediatR;

namespace Internal.Audit.Application.Features.Designation.Commands.AddDesignation;
public class AddDesignationCommandHandler : IRequestHandler<AddDesignationCommand, AddDesignationResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDesignationCommandRepository _designationRepository;
    private readonly IMapper _mapper;

    public AddDesignationCommandHandler(IDesignationCommandRepository designationRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _designationRepository = designationRepository ?? throw new ArgumentNullException(nameof(designationRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddDesignationResponseDTO> Handle(AddDesignationCommand request, CancellationToken cancellationToken)
    {       
        var designation = _mapper.Map<Domain.Entities.common.Designation>(request);
        designation.IsActive = true;
        var newDesignation = await _designationRepository.Add(designation);
        var rowsAffected = await _unitOfWork.CommitAsyncwithErrorMsg();

        if (rowsAffected.Item1 == -1)
        {
            return new AddDesignationResponseDTO(newDesignation.Id, false, rowsAffected.Item2);
        }

        return new AddDesignationResponseDTO(newDesignation.Id, rowsAffected.Item1 > 0, rowsAffected.Item1 > 0 ? "Designation Added Successfully!" : "Error while creating Designation!");

    }
}

