using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.EmailConfigs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Commands.UpdateEmailConfig
{
    public class UpdateEmailConfigCommandHandler : IRequestHandler<UpdateEmailConfigCommand, UpdateEmailConfigResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailConfigCommandRepository _emailConfigRepository;
        private readonly IMapper _mapper;
        public UpdateEmailConfigCommandHandler(IEmailConfigCommandRepository emailConfigRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _emailConfigRepository = emailConfigRepository ?? throw new ArgumentNullException(nameof(emailConfigRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<UpdateEmailConfigResponseDTO> Handle(UpdateEmailConfigCommand request, CancellationToken cancellationToken)
        {
            var config = await _emailConfigRepository.Get(request.Id);
            var mappedConfig = _mapper.Map(request, config);
            var updatedConfig = await _emailConfigRepository.Update(mappedConfig);
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new UpdateEmailConfigResponseDTO(updatedConfig.Id, rowsAffected > 0, rowsAffected > 0 ? "Email Configuration Updated Successfully!" : "Error while updating Email Configuration!");
        }
    }
}
