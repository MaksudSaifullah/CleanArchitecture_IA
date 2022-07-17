using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.EmailConfigs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Commands.DeleteEmailConfig;
public class DeleteEmailConfigCommandHandler : IRequestHandler<DeleteEmailConfigCommand, DeleteEmailConfigResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailConfigCommandRepository _emailConfigRepository;
    private readonly IMapper _mapper;
    public DeleteEmailConfigCommandHandler(IEmailConfigCommandRepository emailConfigRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _emailConfigRepository = emailConfigRepository ?? throw new ArgumentNullException(nameof(emailConfigRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<DeleteEmailConfigResponseDTO> Handle(DeleteEmailConfigCommand request, CancellationToken cancellationToken)
    {
        var emailConfig = await _emailConfigRepository.Get(request.Id);
        emailConfig.IsDeleted = true;
        var mappedEmailConfig = _mapper.Map(request, emailConfig);
        await _emailConfigRepository.Update(mappedEmailConfig);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteEmailConfigResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Email Configuration Deleted Successfully!" : "Error while deleting Email Configuration!");
    }
}
