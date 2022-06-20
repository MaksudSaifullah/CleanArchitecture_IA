using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.security;
using Internal.Audit.Domain.Entities.Security;
using MediatR;

namespace Internal.Audit.Application.Features.UserRegistration.Commands.AddUserRegistration
{
    public class AddUserRegistrationCommandHandler : IRequestHandler<AddUserRegistrationCommand, AddUserRegistrationResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Contracts.Persistent.UserRegistration.IUserCommandRepository _userRepository;
        private readonly IUserCountryCommandRepository _userCountryRepository;
        private readonly IEmployeeCommandRepository _employeeRepository;
        private readonly IUserRoleCommandRepository _userRole;
        private readonly IMapper _mapper;
        public AddUserRegistrationCommandHandler(IUnitOfWork unitOfWork, Contracts.Persistent.UserRegistration.IUserCommandRepository userRepository, IUserCountryCommandRepository userCountryRepository, IEmployeeCommandRepository employeeRepository, IMapper mapper, IUserRoleCommandRepository userRole)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _userCountryRepository = userCountryRepository;
            _userRole = userRole;
        }
        public async Task<AddUserRegistrationResponseDTO> Handle(AddUserRegistrationCommand request, CancellationToken cancellationToken)
        {
            var gid = Guid.NewGuid();
            request.User.Id = gid;
            var user = _mapper.Map<User>(request.User);
            await _userRepository.Add(user);

            request.Employee.UserId= gid;
            var employee = _mapper.Map<Employee>(request.Employee);
            await _employeeRepository.Add(employee);

            foreach (var item in request.UserCountry)
            {
                item.UserId = gid;
            }
            var userCountry = _mapper.Map<List<UserCountry>>(request.UserCountry);
            await _userCountryRepository.Add(userCountry);

            foreach (var item in request.UserRole)
            {
                item.UserId = gid;
            }
            var userRole = _mapper.Map<List<UserRole>>(request.UserRole);
            await _userRole.Add(userRole);

            var rowsAffected = await _unitOfWork.CommitAsync();

            return new AddUserRegistrationResponseDTO(user.Id, rowsAffected > 0, rowsAffected > 0 ? "User registered Successfully!" : "Error while registering User!");
        }
    }

}