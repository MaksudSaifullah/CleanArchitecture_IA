using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserRegistration.Commands.DeleteUserRegistration;

public class DeleteUserRegistrationCommandHandler : IRequestHandler<DeleteUserRegistrationCommand, DeleteUserRegistrationResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserCommandRepository _userRepository;
    private readonly IUserCountryCommandRepository _userCountryRepository;
    private readonly IEmployeeCommandRepository _employeeRepository;
    private readonly IUserRoleCommandRepository _userRole;
    private readonly IUserRoleQueryRepository _userRoleQueryRepository;
    private readonly IUserCountryQueryRepository _userCountryQueryRepository;
    private readonly IEmployeeQueryRepository _employeeQueryRepository;

    private readonly IMapper _mapper;
    public DeleteUserRegistrationCommandHandler(IUnitOfWork unitOfWork, IUserCommandRepository userRepository, IUserCountryCommandRepository userCountryRepository, IEmployeeCommandRepository employeeRepository, IMapper mapper, IUserRoleCommandRepository userRole, IUserCountryQueryRepository userCountryQueryRepository, IUserRoleQueryRepository userRoleQueryRepository, IEmployeeQueryRepository employeeQueryRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _employeeRepository = employeeRepository;
        _userCountryRepository = userCountryRepository;
        _userRole = userRole;
        _userCountryQueryRepository = userCountryQueryRepository;
        _userRoleQueryRepository = userRoleQueryRepository;
        _employeeQueryRepository = employeeQueryRepository;
    }
    public async Task<DeleteUserRegistrationResponseDTO> Handle(DeleteUserRegistrationCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.userId);
        if (user == null)
            return new DeleteUserRegistrationResponseDTO(request.userId, false, "Invalid User Id");
        //user.IsDeleted = true;
        //await _userRepository.Update(user);

        //var employee = await _employeeQueryRepository.GetAllUserListByUserId(request.userId);
        //if (employee == null)
        //    return new DeleteUserRegistrationResponseDTO(request.userId, false, "Doesn't have Employee Id for given user");
        //foreach (var item in employee)
        //{
        //    item.IsDeleted = true;
        //}
        //await _employeeRepository.Update(employee);

        //var userCountryList = await _userCountryQueryRepository.GetAllUserCountryListByUserId(request.userId);         
        //foreach (var item in userCountryList)
        //{
        //    item.IsDeleted = true;
        //}
        //await _userCountryRepository.Update(userCountryList);

        //var userRoleList = await _userRoleQueryRepository.GetAllUserRoleListByUserId(request.userId);
        //foreach (var item in userRoleList)
        //{
        //    item.IsDeleted = true;
        //}
        //await _userRole.Update(userRoleList);
        //var rowsAffected = await _unitOfWork.CommitAsync();
        var rowsAffected = 0;
        return new DeleteUserRegistrationResponseDTO(user.Id, rowsAffected > 0, rowsAffected > 0 ? "User Deleted successfully!" : "Error while deleteing User!");
    }
}

