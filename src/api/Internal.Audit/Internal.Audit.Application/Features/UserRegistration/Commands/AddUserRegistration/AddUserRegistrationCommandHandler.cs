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
        private readonly IUserCommandRepository _userRepository;
        private readonly IUserCountryCommandRepository _userCountryRepository;
        private readonly IEmployeeCommandRepository _employeeRepository;
        private readonly IUserRoleCommandRepository _userRole;
        private readonly IMapper _mapper;
        public AddUserRegistrationCommandHandler(IUnitOfWork unitOfWork, IUserCommandRepository userRepository, IUserCountryCommandRepository userCountryRepository, IEmployeeCommandRepository employeeRepository, IMapper mapper, IUserRoleCommandRepository userRole)
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
            string errorMessage = string.Empty;
            var existsEmail = _employeeRepository.Get(x=>x.Email==request.Employee.Email);
            if (existsEmail.Result.Count() > 0)
            {
                errorMessage += "Email already in use ";
               // return new AddUserRegistrationResponseDTO(Guid.NewGuid(), false, "This email already used");

            }
            var existsuser = _userRepository.Get(x => x.UserName == request.User.UserName && x.IsDeleted==false);
            if (existsuser.Result.Count() > 0)
            {
                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    errorMessage += " , This username already in use ";
                }
                else
                {
                    errorMessage += "This username already in use ";
                }
                    
               // return new AddUserRegistrationResponseDTO(Guid.NewGuid(), false, "This username already used");

            }
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                return new AddUserRegistrationResponseDTO(Guid.NewGuid(), false, errorMessage);
            }

            var gid = Guid.NewGuid();
            request.User.Id = gid;
            var user = _mapper.Map<User>(request.User);
            await _userRepository.Add(user);

            request.Employee.UserId= gid;
            var employee = _mapper.Map<Employee>(request.Employee);
            await _employeeRepository.Add(employee);
            
            request.UserCountry.ForEach(i => i.UserId = gid);           
            var userCountry = _mapper.Map<List<UserCountry>>(request.UserCountry);
            await _userCountryRepository.Add(userCountry);

            request.UserRole.ForEach(i => i.UserId = gid);
            var userRole = _mapper.Map<List<UserRole>>(request.UserRole);
            await _userRole.Add(userRole);

            var rowsAffected = await _unitOfWork.CommitAsync();

            return new AddUserRegistrationResponseDTO(user.Id, rowsAffected > 0, rowsAffected > 0 ? "User registered Successfully!" : "Error while registering User!");
        }
    }

}