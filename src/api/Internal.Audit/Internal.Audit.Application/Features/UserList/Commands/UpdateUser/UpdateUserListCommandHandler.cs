using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.UserList;
using Internal.Audit.Domain.Entities.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserList.Commands.UpdateUser;
public class UpdateUserListCommandHandler : IRequestHandler<UpdateUserListCommand, UpdateUserListResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserListCommandRepository _userListRepository;
    private readonly IUpdateEmployeeCommandRepository _employeeRepository;
    private readonly IUpdateUserCountryCommandRepository _userCountryRepository;
    private readonly IUpdateUserRoleCommandRepository _userRoleRepository;
    

    private readonly IMapper _mapper;
    public UpdateUserListCommandHandler(IUserListCommandRepository userListRepository, IUpdateEmployeeCommandRepository employeeRepository, IUpdateUserCountryCommandRepository userCountryRepository, IUpdateUserRoleCommandRepository userRoleRepository,  IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userListRepository=userListRepository;
        _employeeRepository=employeeRepository;
        _userCountryRepository=userCountryRepository;
        _userRoleRepository=userRoleRepository;
        _mapper=mapper; 
        _unitOfWork=unitOfWork;
    }
    public async Task<UpdateUserListResponseDTO> Handle(UpdateUserListCommand request, CancellationToken cancellationToken)
    {
        var employee = (await _employeeRepository.Get(x=>x.UserId == request.UserEmployee.UserId)).FirstOrDefault();
        if (employee == null)
            return new UpdateUserListResponseDTO(request.UserEmployee.EmployeeId, false, "Invalid Employee Id");
        employee = _mapper.Map(request.UserEmployee, employee);
        await _employeeRepository.Update(employee);

        var userCountry = (await _userCountryRepository.Get( x=>x.UserId== request.UserCountry.UserId)).FirstOrDefault();
        if (userCountry == null)
            return new UpdateUserListResponseDTO(request.UserCountry.UserId, false, "Invalid User Id in Country");
        userCountry = _mapper.Map(request.UserCountry, userCountry);
        await _userCountryRepository.Update(userCountry);


        var userRole = (await _userRoleRepository.Get(x=>x.UserId== request.UserRole.UserId)).FirstOrDefault();
        if (userRole == null)
            return new UpdateUserListResponseDTO(request.UserRole.UserId, false, "Invalid User Id in Role");
        userRole = _mapper.Map(request.UserRole, userRole);
        await _userRoleRepository.Update(userRole);



        //var user = _mapper.Map<User>(request);
        //var modifiedUser = await _userListRepository.Update(user);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateUserListResponseDTO(request.UserCountry.UserId, rowsAffected > 0, rowsAffected > 0 ? "User Updated Successfully!" : "Error while updating user!");
    }
}
