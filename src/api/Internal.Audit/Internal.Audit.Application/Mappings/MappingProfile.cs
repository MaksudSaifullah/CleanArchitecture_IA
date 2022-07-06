
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
//using Internal.Audit.Application.Features.Users.Commands.AddUser;
//using Internal.Audit.Application.Features.Users.Commands.UpdateUser;
//using Internal.Audit.Application.Features.Users.Queries.GetUserList;
using Internal.Audit.Application.Features.Roles.Commands.AddRole;
using Internal.Audit.Application.Features.Roles.Commands.DeleteRole;
using Internal.Audit.Application.Features.Roles.Commands.UpdateRole;
using Internal.Audit.Application.Features.Roles.Queries.GetRoleById;
using Internal.Audit.Application.Features.Roles.Queries.GetRolesList;
using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.common;
using Internal.Audit.Domain.Entities.Security;
//using Internal.Audit.Application.Features.UserCountries.Commands.AddUserCountry;
using Internal.Audit.Domain.Entities.security;
using Internal.Audit.Application.Features.AccessPrivilege.Commands.AddAccessPrivilege;
using Internal.Audit.Application.Features.AccessPrivilege.Commands.UpdateAccessPrivilege;
using Internal.Audit.Application.Features.AccessPrivilege.Queries.GetAccessPrivilege;
using Internal.Audit.Domain.Entities.Common;
using Internal.Audit.Application.Features.Module.Queries.GetModuleList;
using Internal.Audit.Application.Features.AuditFeature.Queries.GetFeatureList;
using Internal.Audit.Application.Features.AuditAction.Queries.GetActionList;
using Internal.Audit.Application.Features.RiskProfiles.Commands.AddRiskProfile;
using Internal.Audit.Application.Features.RiskProfiles.Commands.UpdateRiskProfile;
using Internal.Audit.Application.Features.RiskProfiles.Commands.DeleteRiskProfile;
using Internal.Audit.Application.Features.RiskProfiles.Queries.GetRiskProfileList;
using Internal.Audit.Application.Features.RiskProfiles.Queries.GetRiskProfileById;
using Internal.Audit.Application.Features.Dashboards.Queries.GetDashboardList;
using Internal.Audit.Application.Features.Dashboards.Queries.GetDashboardById;
using Internal.Audit.Application.Features.Dashboards.Commands.AddDashboard;
using Internal.Audit.Application.Features.Dashboards.Commands.UpdateDashboard;
using Internal.Audit.Application.Features.Dashboards.Commands.DeleteDashboard;
using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Application.Features.UserList.Queries.GetUserList;
using Internal.Audit.Application.Features.UserList.Commands.UpdateUser;

using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetAuditConducted;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetControlFrequency;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetDetestConclusion;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetEmailType;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetIssueStatus;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetLevelOfImpact;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetLevelOfLikelihood;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetLOProductivity;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetNatureOfControlActivity;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetRiskRating;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetRiskRatingName;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetSampledMonth;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetSampleSelectionMethod;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetYear;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetYesNo;
using Internal.Audit.Domain.Entities.Config;
using Internal.Audit.Application.Features.UserRegistration.Commands.AddUserRegistration;
using Internal.Audit.Application.Features.UserRegistration.Queries.GetAllUserList;
using Internal.Audit.Application.Features.UserRegistration.Queries.GetALlUserListById;
using Internal.Audit.Application.Features.UserRegistration.Commands.UpdateUserRegistration;
using Internal.Audit.Application.Features.UserRegistration.Commands.DeleteUserRegistration;
using Internal.Audit.Application.Features.Designation.Queries.GetDesignationById;
using Internal.Audit.Application.Features.ModulewiseRolePrivilege.Commands.AddModulewiseRolePrivilege;
using Internal.Audit.Application.Features.ModulewiseRolePrivilege.Commands.UpdateModulewisePrivilege;
using Internal.Audit.Application.Features.ModulewiseRolePrivilege.Quiries.GetModilewiseRoleByRoleIdList;
using Internal.Audit.Application.Features.ModuleFeature.Quiries.GetAllModuleList;
using Internal.Audit.Application.Features.ModuleFeature.Quiries.GetOnlyModuleList;

namespace Internal.Audit.Application.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        //CreateMap<User, UserDTO>().ReverseMap();
        //CreateMap<User, AddUserCommand>().ReverseMap();
        //CreateMap<User, Features.Users.Commands.UpdateUser.UpdateUserCommand>().ReverseMap();
        CreateMap<Country, CountryDTO>().ReverseMap();
        CreateMap<Country, CountryByIdDTO>().ReverseMap();
        CreateMap<Country, AddCountryResponseDTO>().ReverseMap();
        CreateMap<Country, AddCountryCommand>().ReverseMap();
        CreateMap<Country, UpdateCountryResponseDTO>().ReverseMap();
        CreateMap<Country, UpdateCountryCommand>().ReverseMap();
        CreateMap<Country, DeleteCountryResponseDTO>().ReverseMap();
        CreateMap<Country, DeleteCountryCommand>().ReverseMap();

        CreateMap<RiskProfile, RiskProfileDTO>().ReverseMap();
        CreateMap<RiskProfile, RiskProfileByIdDTO>().ReverseMap();
        CreateMap<RiskProfile, AddRiskProfileResponseDTO>().ReverseMap();
        CreateMap<RiskProfile, AddRiskProfileCommand>().ReverseMap();
        CreateMap<RiskProfile, UpdateRiskProfileResponseDTO>().ReverseMap();
        CreateMap<RiskProfile, UpdateRiskProfileCommand>().ReverseMap();
        CreateMap<RiskProfile, DeleteRiskProfileResponseDTO>().ReverseMap();
        CreateMap<RiskProfile, DeleteRiskProfileCommand>().ReverseMap();

        CreateMap<DashBoardBase, DashboardDTO>().ReverseMap();
        CreateMap<DashBoardBase, DashboardByIdDTO>().ReverseMap();
        CreateMap<DashBoardBase, AddDashboardResponseDTO>().ReverseMap();
        CreateMap<DashBoardBase, AddDashboardCommand>().ReverseMap();
        CreateMap<DashBoardBase, UpdateDashboardResponseDTO>().ReverseMap();
        CreateMap<DashBoardBase, UpdateDashboardCommand>().ReverseMap();
        CreateMap<DashBoardBase, DeleteDashboardResponseDTO>().ReverseMap();
        CreateMap<DashBoardBase, DeleteDashboardCommand>().ReverseMap();

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
        CreateMap<Designation, GetDesignationByIdDTO>().ReverseMap();

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


        CreateMap<AuditModule, GetActionModuleListResponseDTO>().ReverseMap();
        CreateMap<AuditFeature, GetAuditFeatureListResponseDTO>().ReverseMap();
        CreateMap<AuditAction, GetAuditActionListResponseDTO>().ReverseMap();

        CreateMap<CommonValueAndType, AuditConductedDTO>().ReverseMap();
        //CreateMap<CommonValueAndType, AuditConductedDTO>().ReverseMap();
        CreateMap<CommonValueAndType, ControlFrequencyDTO>().ReverseMap();
        CreateMap<CommonValueAndType, DetestConclusionDTO>().ReverseMap();
        CreateMap<CommonValueAndType, EmailTypeDTO>().ReverseMap();
        CreateMap<CommonValueAndType, IssueStatusDTO>().ReverseMap();
        CreateMap<CommonValueAndType, LevelOfImpactDTO>().ReverseMap();
        CreateMap<CommonValueAndType, LevelOfLikelihoodDTO>().ReverseMap();
        CreateMap<CommonValueAndType, LOProductivityDTO>().ReverseMap();
        CreateMap<CommonValueAndType, NatureOfControlActivityDTO>().ReverseMap();
        CreateMap<CommonValueAndType, RiskRatingDTO>().ReverseMap();
        CreateMap<CommonValueAndType, RiskRatingNameDTO>().ReverseMap();
        CreateMap<CommonValueAndType, SampledMonthDTO>().ReverseMap();
        CreateMap<CommonValueAndType, SampleSelectionMethodDTO>().ReverseMap();
        CreateMap<CommonValueAndType, YearDTO>().ReverseMap();
        CreateMap<CommonValueAndType, YesNoDTO>().ReverseMap();
        CreateMap<CompositeUser, Features.UserList.Queries.GetUserList.GetUserListResponseDTO>().ReverseMap();
        CreateMap<Employee, UpdateEmployeeCommandDTO>().ReverseMap();
        CreateMap<UserRole, UpdateUserRoleCommandDTO>().ReverseMap();
        CreateMap<UserCountry, UpdateUserCountryCommandDTO>().ReverseMap();
        CreateMap<User, Features.UserList.Commands.UpdateUser.UpdateUserCommand>().ReverseMap();

        CreateMap<User, AddUserNewCommand>().ReverseMap();
        CreateMap<UserCountry, AddUserCountryCommand>().ReverseMap();
        CreateMap<UserRole, AddUserRoleCommand>().ReverseMap();
        CreateMap<Employee, AddEmployeeCommand>().ReverseMap();
        CreateMap<User, Features.UserRegistration.Queries.GetAllUserList.GetUserListResponseDTO>().ReverseMap();
        CreateMap<User, GetALlUserListByIdResponseDTO>().ReverseMap();

        CreateMap<User, AddUserUpdateCommand>().ReverseMap();
        CreateMap<UserCountry, AddUserCountryUpdateCommand>().ReverseMap();
        CreateMap<UserRole, AddUserRoleUpdateCommand>().ReverseMap();
        CreateMap<Employee, AddEmployeeUpdateCommand>().ReverseMap();
        CreateMap<User, DeleteUserRegistrationCommand>().ReverseMap();
        CreateMap<User, DeleteUserRegistrationResponseDTO>().ReverseMap();

        CreateMap<ModulewiseRolePriviliege, AddModulewiseRolePrivilegeCommand>().ReverseMap();
        CreateMap<ModulewiseRolePriviliege, UpdateModulewiseRolePrivilegeCommand>().ReverseMap();
        CreateMap<ModulewiseRolePriviliege, GetModulewiseRolePrivilegeByRoleIdListResponseDTO>().ReverseMap();

        CreateMap<ModuleFeature, GetAllModuleListResponseDTO>().ReverseMap();
        CreateMap<AuditModule, GetOnlyModuleListResponseDTO>().ReverseMap();
    }
}
