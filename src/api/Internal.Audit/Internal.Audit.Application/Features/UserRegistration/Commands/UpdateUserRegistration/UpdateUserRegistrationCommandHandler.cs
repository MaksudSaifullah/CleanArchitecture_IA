using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.security;
using Internal.Audit.Domain.Entities.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserRegistration.Commands.UpdateUserRegistration
{
    public class UpdateUserRegistrationCommandHandler : IRequestHandler<UpdateUserRegistrationCommand, UpdateUserRegistrationResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserCommandRepository _userRepository;
        private readonly IUserCountryCommandRepository _userCountryRepository;
        private readonly IEmployeeCommandRepository _employeeRepository;
        private readonly IUserRoleCommandRepository _userRole;
        private readonly IUserRoleQueryRepository _userRoleQueryRepository;
        private readonly IUserCountryQueryRepository _userCountryQueryRepository;

        private readonly IMapper _mapper;
        public UpdateUserRegistrationCommandHandler(IUnitOfWork unitOfWork, IUserCommandRepository userRepository, IUserCountryCommandRepository userCountryRepository, IEmployeeCommandRepository employeeRepository, IMapper mapper, IUserRoleCommandRepository userRole, IUserCountryQueryRepository userCountryQueryRepository, IUserRoleQueryRepository userRoleQueryRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _userCountryRepository = userCountryRepository;
            _userRole = userRole;
            _userCountryQueryRepository = userCountryQueryRepository;
            _userRoleQueryRepository = userRoleQueryRepository;
        }
        public async Task<UpdateUserRegistrationResponseDTO> Handle(UpdateUserRegistrationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.User.Id);
            if (user == null)
                return new UpdateUserRegistrationResponseDTO(request.User.Id, false, "Invalid User Id");
            user = _mapper.Map(request.User, user);
            await _userRepository.Update(user);

            var employee = await _employeeRepository.Get(request.Employee.Id);
            if (employee == null)
                return new UpdateUserRegistrationResponseDTO(request.Employee.Id, false, "Invalid Employee Id");
            employee = _mapper.Map(request.Employee, employee);
            await _employeeRepository.Update(employee);

            await _userCountryRepository.Delete(await _userCountryQueryRepository.GetAllUserCountryListByUserId(request.User.Id));
            await _userRole.Delete(await _userRoleQueryRepository.GetAllUserRoleListByUserId(request.User.Id));

           
            var userCountry = _mapper.Map<List<UserCountry>>(request.UserCountry);
            await _userCountryRepository.Add(userCountry);

          
            var userRole = _mapper.Map<List<UserRole>>(request.UserRole);
            await _userRole.Add(userRole);


            var rowsAffected = await _unitOfWork.CommitAsync();

            return new UpdateUserRegistrationResponseDTO(user.Id, rowsAffected > 0, rowsAffected > 0 ? "User registered Updated!" : "Error while updating User!");
        }
    }
}
