
using AutoMapper;
using Internal.Audit.Application.Features.Countries.Commands.AddCountry;
using Internal.Audit.Application.Features.Countries.Commands.DeleteCountry;
using Internal.Audit.Application.Features.Countries.Commands.UpdateCountry;
using Internal.Audit.Application.Features.Countries.Queries.GetCountryById;
using Internal.Audit.Application.Features.Countries.Queries.GetCountryList;
using Internal.Audit.Application.Features.Designation.Commands.AddDesignation;
using Internal.Audit.Application.Features.Designation.Commands.DeleteDesignation;
using Internal.Audit.Application.Features.Designation.Commands.UpdateDesignation;
using Internal.Audit.Application.Features.Designation.Queries.GetDesignationList;
using Internal.Audit.Application.Features.Users.Commands.AddUser;
using Internal.Audit.Application.Features.Users.Commands.UpdateUser;
using Internal.Audit.Application.Features.Users.Queries.GetUserList;
using Internal.Audit.Application.Features.Roles.Commands.AddRole;
using Internal.Audit.Application.Features.Roles.Commands.DeleteRole;
using Internal.Audit.Application.Features.Roles.Commands.UpdateRole;
using Internal.Audit.Application.Features.Roles.Queries.GetRoleById;
using Internal.Audit.Application.Features.Roles.Queries.GetRolesList;
using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.common;
using Internal.Audit.Domain.Entities.Security;
using Internal.Audit.Application.Features.UserCountries.Commands.AddUserCountry;
using Internal.Audit.Domain.Entities.security;
using Internal.Audit.Application.Features.AccessPrivilege.Commands.AddAccessPrivilege;
using Internal.Audit.Application.Features.AccessPrivilege.Commands.UpdateAccessPrivilege;
using Internal.Audit.Application.Features.AccessPrivilege.Queries.GetAccessPrivilege;
using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Application.Features.UserList.Queries.GetUserList;
using Internal.Audit.Application.Features.UserList.Commands.UpdateUser;

namespace Internal.Audit.Application.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, AddUserCommand>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<Country, CountryDTO>().ReverseMap();
        CreateMap<Country, CountryByIdDTO>().ReverseMap();
        CreateMap<Country, AddCountryResponseDTO>().ReverseMap();
        CreateMap<Country, AddCountryCommand>().ReverseMap();
        CreateMap<Country, UpdateCountryResponseDTO>().ReverseMap();
        CreateMap<Country, UpdateCountryCommand>().ReverseMap();
        CreateMap<Country, DeleteCountryResponseDTO>().ReverseMap();
        CreateMap<Country, DeleteCountryCommand>().ReverseMap();
        CreateMap<Designation, AddDesignationResponseDTO>().ReverseMap();
        CreateMap<Designation, AddDesignationCommand>().ReverseMap();
        CreateMap<Role, RoleDTO>().ReverseMap();
        CreateMap<Role, RoleByIdDTO>().ReverseMap();
        CreateMap<Role, AddRoleResponseDTO>().ReverseMap();
        CreateMap<Role, AddRoleCommand>().ReverseMap();
        CreateMap<Role, UpdateRoleResponseDTO>().ReverseMap();
        CreateMap<Role, UpdateRoleCommand>().ReverseMap();
        CreateMap<Role, DeleteRoleResponseDTO>().ReverseMap();
        CreateMap<Role, DeleteRoleCommand>().ReverseMap();
        CreateMap<Designation, UpdateDesignationResponseDTO>().ReverseMap();
        CreateMap<Designation, UpdateDesignationCommand>().ReverseMap();
        CreateMap<Designation, DeleteDesignationResponseDTO>().ReverseMap();
        CreateMap<Designation, DeleteDesignationCommand>().ReverseMap();
        CreateMap<Designation, GetDesignationListResponseDTO>().ReverseMap();
        CreateMap<UserCountry, AddUserCountryCommand>().ReverseMap();

        CreateMap<PasswordPolicy, GetPasswordPolicyDTO>().ReverseMap();
        CreateMap<UserLockingPolicy, GetUserLockingPolicyDTO>().ReverseMap();
        CreateMap<SessionPolicy, GetSessionPolicyDTO>().ReverseMap();
        CreateMap<PasswordPolicy, AddAccessPrivilegeResponseDTO>().ReverseMap();
        CreateMap<PasswordPolicy, AddPasswordPolicyDTO>().ReverseMap();
        CreateMap<SessionPolicy, AddAccessPrivilegeResponseDTO>().ReverseMap();
        CreateMap<SessionPolicy, AddSessionPolicyDTO>().ReverseMap();
        CreateMap<UserLockingPolicy, AddAccessPrivilegeResponseDTO>().ReverseMap();
        CreateMap<UserLockingPolicy, AddUserLockingPolicyDTO>().ReverseMap();
        CreateMap<PasswordPolicy, UpdateAccessPrivilegeResponseDTO>().ReverseMap();
        CreateMap<PasswordPolicy, UpdatePasswordPolicyCommandDTO>().ReverseMap();
        CreateMap<SessionPolicy, UpdateAccessPrivilegeResponseDTO>().ReverseMap();
        CreateMap<SessionPolicy, UpdateSessionPolicyCommandDTO>().ReverseMap();
        CreateMap<UserLockingPolicy, UpdateAccessPrivilegeResponseDTO>().ReverseMap();
        CreateMap<UserLockingPolicy, UpdateUserLockingPolicyCommandDTO>().ReverseMap();
        CreateMap<CompositeUser, GetUserListResponseDTO>().ReverseMap();
        CreateMap<Employee, UpdateEmployeeCommandDTO>().ReverseMap();
        CreateMap<UserRole, UpdateUserRoleCommandDTO>().ReverseMap();
        CreateMap<UserCountry, UpdateUserCountryCommandDTO>().ReverseMap();
    }
}
