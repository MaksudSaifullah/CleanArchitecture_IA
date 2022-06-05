using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Application.Contracts.Persistent.Roles;
using Internal.Audit.Application.Contracts.Persistent.UserCountries;
using Internal.Audit.Domain.Entities.Security;
using MediatR;

namespace Internal.Audit.Application.Features.UserCountries.Commands.AddUserCountry
{
    public class AddUserCountryCommandHandler : IRequestHandler<AddUserCountryCommand, AddUserCountryResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserCountryCommandRepository _userCountryRepository;
        private readonly IMapper _mapper;
        public AddUserCountryCommandHandler(IUnitOfWork unitOfWork, IUserCountryCommandRepository userCountryRepository, IMapper mapper)
        {
            _userCountryRepository = userCountryRepository ?? throw new ArgumentNullException(nameof(userCountryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            
        }
        public async Task<AddUserCountryResponseDTO> Handle(AddUserCountryCommand request, CancellationToken cancellationToken)
        {
            var userCountry = _mapper.Map<UserCountry>(request);
            var newuserCountry = await _userCountryRepository.Add(userCountry);
            var rowsAffected = await _unitOfWork.CommitAsync();

            return new AddUserCountryResponseDTO(newuserCountry.Id, rowsAffected > 0, rowsAffected > 0 ? "User Country Added Successfully!" : "Error while creating User Country!");
        }
    }
}
