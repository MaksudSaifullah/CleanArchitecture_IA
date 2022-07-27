using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.EmailConfigs;
using Internal.Audit.Domain.Entities.config;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Commands.AddEmailConfig;
public class AddEmailConfigCommandHandler : IRequestHandler<AddEmailConfigCommand, AddEmailConfigResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailConfigCommandRepository _emailConfigRepository;
    private readonly IMapper _mapper;
    public AddEmailConfigCommandHandler(IEmailConfigCommandRepository emailConfigRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _emailConfigRepository = emailConfigRepository ?? throw new ArgumentNullException(nameof(emailConfigRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddEmailConfigResponseDTO> Handle(AddEmailConfigCommand request, CancellationToken cancellationToken)
    {
        var emailConfig = _mapper.Map<EmailConfiguration>(request);
        var newEmailConfig = await _emailConfigRepository.Add(emailConfig);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddEmailConfigResponseDTO(newEmailConfig.Id, rowsAffected > 0, rowsAffected > 0 ? "Email Configuration Added Successfully!" : "Error while creating Email Configuration!");
    }
}
