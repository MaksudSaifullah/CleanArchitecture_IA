
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
using Internal.Audit.Domain.Entities.config;
using Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailConfigList;
using Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailConfigById;
using Internal.Audit.Application.Features.EmailConfig.Commands.AddEmailConfig;
using Internal.Audit.Application.Features.EmailConfig.Commands.DeleteEmailConfig;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Application.Features.RiskCriterias.Queries.GetRiskCriteriaList;
using Internal.Audit.Application.Features.RiskCriterias.Queries.GetRiskCriteriaById;
using Internal.Audit.Application.Features.RiskCriterias.Commands.AddRiskCriteria;
using Internal.Audit.Application.Features.RiskCriterias.Commands.UpdateRiskCriteria;
using Internal.Audit.Application.Features.RiskCriterias.Commands.DeleteRiskCriteria;
using Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadList;
using Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadById;
using Internal.Audit.Application.Features.TopicHeads.Commands.AddTopicHead;
using Internal.Audit.Application.Features.TopicHeads.Commands.UpdateTopicHead;
using Internal.Audit.Application.Features.TopicHeads.Commands.DeleteTopicHead;
using Internal.Audit.Application.Features.DocumentSources.Queries.GetAllDocumentSource;
using Internal.Audit.Application.Features.Documents.Commands.AddDocumentCommand;
using Internal.Audit.Application.Features.Documents.Commands.UpdateDocumentCommand;
using Internal.Audit.Application.Features.Documents.Commands.DeleteDocumentCommand;
using Internal.Audit.Application.Features.Documents.Queries.GetByDocumentId;
using Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailTypeList;

using Internal.Audit.Application.Features.RiskAssessments.Commands.AddRiskAssessment;
using Internal.Audit.Application.Features.RiskAssessments.Commands.UpdateRiskAssessment;
using Internal.Audit.Application.Features.RiskAssessments.Commands.DeleteRiskAssessment;
using Internal.Audit.Application.Features.RiskAssessments.Queries.GetRiskAssessmentList;
using Internal.Audit.Application.Features.RiskAssessments.Queries.GetRiskAssessmentById;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetAuditType;
using Internal.Audit.Application.Features.EmailConfig.Commands.UpdateEmailConfig;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetAuditFrequency;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetAuditScore;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetCommonValueTypeGeneric;
using Internal.Audit.Application.Features.Audit.Queries.GetAuditList;
using Internal.Audit.Application.Features.Audit.Commands.AddAudit;
using Internal.Audit.Application.Features.Audit.Commands.DeleteAudit;
using Internal.Audit.Application.Features.Audit.Queries.GetAuditById;
using Internal.Audit.Application.Features.Audit.Commands.UpdateAudit;

using Internal.Audit.Application.Features.WeightScoreConfigurations.Queries.WeightScoreByCountryId;

using Internal.Audit.Application.Features.AuditFrequencies.Queries.GetAuditFrequencyById;
using Internal.Audit.Application.Features.AuditFrequencies.Commands.AddAuditFrequency;
using Internal.Audit.Application.Features.AuditFrequencies.Commands.UpdateAuditFrequency;
using Internal.Audit.Application.Features.AuditFrequencies.Commands.DeleteAuditFrequency;
using Internal.Audit.Application.Features.AuditFrequencies.Queries.GetAuditFrequencyList;
using Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnaireById;
using Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnnaireList;
using Internal.Audit.Application.Features.Questionnnaires.Commands.AddQuestionnaire;
using Internal.Audit.Application.Features.Questionnnaires.Commands.UpdateQuestionnaire;
using Internal.Audit.Application.Features.Questionnnaires.Commands.DeleteQuestionnaire;
using Internal.Audit.Application.Features.DataRequestQueue.Command.AddDataRequestQueueCommand;
using Internal.Audit.Application.Features.AmbsDataSyncs.Command.AddAmbsDataSyncCommand;
using Internal.Audit.Application.Features.AuditPlans.Queries.GetAuditPlanList;
using Internal.Audit.Application.Features.AuditPlans.Queries.GetAuditPlanById;
using Internal.Audit.Application.Features.AuditPlans.Commands.AddAuditPlan;
using Internal.Audit.Application.Features.AuditPlans.Commands.UpdateAuditPlan;
using Internal.Audit.Application.Features.AuditPlans.Commands.DeleteAuditPlan;
using Internal.Audit.Application.Features.Audit.Queries.GetAuditPlanCodeList;
using Internal.Audit.Application.Features.TestSteps.Queries.GetTestStepList;
using Internal.Audit.Application.Features.TestSteps.Queries.GetTestStepById;
using Internal.Audit.Application.Features.TestSteps.Commands.AddTestStep;
using Internal.Audit.Application.Features.TestSteps.Commands.UpdateTestStep;
using Internal.Audit.Application.Features.TestSteps.Commands.DeleteTestStep;
using Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadByFilter;
using Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnaireByFilter;
using Internal.Audit.Application.Features.Branches.Commands.AddBranchCommand;
using Internal.Audit.Application.Features.Branches.Commands.GetBranchList;
using Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetAmbsDataSyncDataByCountryAndDateInfo;
using Internal.Audit.Application.Features.AuditSchedules.Commands.AddAuditSchedule;
using Internal.Audit.Application.Features.WorkPapers.Queries.GetWorkPaperList;
using Internal.Audit.Application.Features.WorkPapers.Queries.GetWorkPaperById;
using Internal.Audit.Application.Features.WorkPapers.Commands.AddWorkPaper;
using Internal.Audit.Application.Features.WorkPapers.Commands.UpdateWorkPaper;
using Internal.Audit.Application.Features.WorkPapers.Commands.DeleteWorkPaper;
using Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleList;
using Internal.Audit.Application.Features.RiskAssesmentDataManagements.Commands.AddRiskAssesmentDataManagement;
using Internal.Audit.Application.Features.RiskAssesmentDataManagementLogs.Commands.AddRiskAssesmentDataManagementLog;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetSampleSize;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetBranchbyAuditSchedule;
using Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetRiskAssesmentData;
using Internal.Audit.Application.Features.UploadDocuments.Commands.AddUploadDocument;
using Internal.Audit.Application.Features.UploadDocuments.Queries.GetUploadedDocumentListByRoled;
using Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleByPlanId;
using Internal.Audit.Application.Features.Issues.Queries.GetIssueList;
using Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleById;
using Internal.Audit.Application.Features.RiskAssesmentConsolidateDatas.Commands.AddConsolidateData;
using Internal.Audit.Application.Features.RiskAssesmentConsolidateDatas.Queries;
using Internal.Audit.Application.Features.AuditSchedules.Commands.UpdateSchedule;
using Internal.Audit.Application.Features.AuditSchedules.Commands.DeleteAuditSchedule;
using Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadByCountryIdAndDateRange;
using Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleById;
using Internal.Audit.Application.Features.RiskAssesmentConsolidateDatas.Commands.AddConsolidateData;
using Internal.Audit.Application.Features.RiskAssesmentConsolidateDatas.Queries;
using Internal.Audit.Application.Features.AuditSchedules.Commands.UpdateSchedule;
using Internal.Audit.Application.Features.AuditSchedules.Commands.DeleteAuditSchedule;
using Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadByCountryIdAndDateRange;
using Internal.Audit.Application.Features.Issues.Queries.GetIssueById;
using Internal.Audit.Application.Features.Audit.Queries.GetAuditType;
using Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleBranchList;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinuteList;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.AddClosingMeetingMinute;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.UpdateClosingMeetingMinute;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.DeleteClosingMeetingMinute;
using Internal.Audit.Application.Features.WeightScoreConfigurations.Commands.AddWeightScoreCommand;
using Internal.Audit.Application.Features.AuditScheduleConfigurationsOwner.Commands.AddAuditScheduleConfigurationsOwnerCommand;
using Internal.Audit.Application.Features.AuditScheduleConfigurationsOwner.Queries.GetAllByAuditScheduleId;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinuteById;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinutesBaseById;
using Internal.Audit.Application.Features.Issues.Commands.AddIssue;

namespace Internal.Audit.Application.Mappings;

public class MappingProfile : Profile
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
        CreateMap<CompositeRiskProfile, RiskProfileDTO>().ReverseMap();
        CreateMap<CompositeRiskProfile, RiskProfileByIdDTO>().ReverseMap();
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

        CreateMap<CompositEmailConfig, GetEmailConfigByIdResponseDTO>().ReverseMap();
        CreateMap<EmailConfiguration, GetEmailConfigByIdResponseDTO>().ReverseMap();
        CreateMap<EmailConfiguration, AddEmailConfigResponseDTO>().ReverseMap();
        CreateMap<EmailConfiguration, AddEmailConfigCommand>().ReverseMap();
        CreateMap<EmailConfiguration, DeleteEmailConfigCommand>().ReverseMap();
        CreateMap<EmailConfiguration, DeleteEmailConfigResponseDTO>().ReverseMap();
        CreateMap<AuditModule, GetOnlyModuleListResponseDTO>().ReverseMap();
        CreateMap<EmailConfiguration, UpdateEmailConfigCommand>().ReverseMap();

        CreateMap<RiskAssessment, RiskAssessmentDTO>().ReverseMap();
        CreateMap<CompositeRiskAssessment, RiskAssessmentDTO>().ReverseMap();
        CreateMap<CompositeRiskAssessment, RiskAssessmentByIdDTO>().ReverseMap();
        CreateMap<RiskAssessment, RiskAssessmentByIdDTO>().ReverseMap();
        CreateMap<RiskAssessment, AddRiskAssessmentResponseDTO>().ReverseMap();
        CreateMap<RiskAssessment, AddRiskAssessmentCommand>().ReverseMap();
        CreateMap<RiskAssessment, UpdateRiskAssessmentResponseDTO>().ReverseMap();
        CreateMap<RiskAssessment, UpdateRiskAssessmentCommand>().ReverseMap();
        CreateMap<RiskAssessment, DeleteRiskAssessmentResponseDTO>().ReverseMap();
        CreateMap<RiskAssessment, DeleteRiskAssessmentCommand>().ReverseMap();
        CreateMap<AddModulewiseRolePrivilege, ModulewiseRolePriviliege>().ReverseMap();

        CreateMap<RiskCriteria, RiskCriteriaDTO>().ReverseMap();
        CreateMap<CompositeRiskCriteria, RiskCriteriaDTO>().ReverseMap();
        CreateMap<CompositeRiskCriteria, RiskCriteriaByIdDTO>().ReverseMap();
        CreateMap<RiskCriteria, RiskCriteriaByIdDTO>().ReverseMap();
        CreateMap<RiskCriteria, AddRiskCriteriaResponseDTO>().ReverseMap();
        CreateMap<RiskCriteria, AddRiskCriteriaCommand>().ReverseMap();
        CreateMap<RiskCriteria, UpdateRiskCriteriaResponseDTO>().ReverseMap();
        CreateMap<RiskCriteria, UpdateRiskCriteriaCommand>().ReverseMap();
        CreateMap<RiskCriteria, DeleteRiskCriteriaResponseDTO>().ReverseMap();
        CreateMap<RiskCriteria, DeleteRiskCriteriaCommand>().ReverseMap();

        CreateMap<TopicHead, TopicHeadDTO>().ReverseMap();
        CreateMap<TopicHead, TopicHeadByIdDTO>().ReverseMap();
        CreateMap<TopicHead, GetTopicHeadByFilterResponseDTO>().ReverseMap();
        CreateMap<TopicHead, AddTopicHeadCommand>().ReverseMap();
        CreateMap<TopicHead, UpdateTopicHeadCommand>().ReverseMap();
        CreateMap<TopicHead, DeleteTopicHeadCommand>().ReverseMap();
        CreateMap<CompositEmailConfig, GetEmailConfigListResponseDTO>().ReverseMap();
        CreateMap<Domain.CompositeEntities.EmailType, GetEmailTypeListResponseDTO>().ReverseMap();

        CreateMap<DocumentSource, GetAllDocumentSourceDTO>().ReverseMap();
        CreateMap<Document, AddDocumentCommand>().ReverseMap();
        CreateMap<Document, UpdateDocumentCommand>().ReverseMap();
        CreateMap<Document, DeleteDocumentCommand>().ReverseMap();
        CreateMap<Document, GetByDocumentIdResponseDTO>().ReverseMap();
        CreateMap<CommonValueAndType, AuditTypeDTO>().ReverseMap();
        CreateMap<CommonValueAndType, AuditFrequencyTypeDTO>().ReverseMap();
        CreateMap<CommonValueAndType, AuditScoreDTO>().ReverseMap();
        CreateMap<CommonValueAndType, GetCommonValueTypeGenericDTO>().ReverseMap();

        CreateMap<WeightScore, WeightScoreByCountryIdDTO>().ReverseMap();


        CreateMap<AuditFrequency, AuditFrequencyDTO>().ReverseMap();
        CreateMap<CompositeAuditFrequency, AuditFrequencyDTO>().ReverseMap();
        CreateMap<CompositeAuditFrequency, AuditFrequencyByIdDTO>().ReverseMap();
        CreateMap<AuditFrequency, AuditFrequencyByIdDTO>().ReverseMap();
        CreateMap<AuditFrequency, AddAuditFrequencyResponseDTO>().ReverseMap();
        CreateMap<AuditFrequency, AddAuditFrequencyCommand>().ReverseMap();
        CreateMap<AuditFrequency, UpdateAuditFrequencyResponseDTO>().ReverseMap();
        CreateMap<AuditFrequency, UpdateAuditFrequencyCommand>().ReverseMap();
        CreateMap<AuditFrequency, DeleteAuditFrequencyResponseDTO>().ReverseMap();
        CreateMap<AuditFrequency, DeleteAuditFrequencyCommand>().ReverseMap();

        CreateMap<CompositeQuestionnaire, GetQuestionnaireListResponseDTO>().ReverseMap();
        CreateMap<CompositeQuestionnaire, GetQuestionnaireByIdDTO>().ReverseMap();
        CreateMap<CompositeQuestionnaire, GetQuestionnaireByFilterResponseDTO>().ReverseMap();
        CreateMap<Questionnaire, AddQuestionnaireResponseDTO>().ReverseMap();
        CreateMap<Questionnaire, AddQuestionnaireCommand>().ReverseMap();
        CreateMap<Questionnaire, UpdateQuestionnaireResponseDTO>().ReverseMap();
        CreateMap<Questionnaire, UpdateQuestionnaireCommand>().ReverseMap();
        CreateMap<Questionnaire, DeleteQuestionnaireResponseDTO>().ReverseMap();
        CreateMap<Questionnaire, DeleteQuestionnaireCommand>().ReverseMap();

        CreateMap<DataRequestQueueService, AddDatarequestCommand>().ReverseMap();
        CreateMap<AmbsDataSync, AddAmbsDataSyncCommand>().ReverseMap();
        CreateMap<AmbsDataSync, AddAmbsDataSyncCommandRequest>().ReverseMap();

        CreateMap<AuditPlan, AuditPlanDTO>().ReverseMap();
        CreateMap<CompositeAuditPlan, AuditPlanDTO>().ReverseMap();
        CreateMap<CompositeAuditPlan, AuditPlanByIdDTO>().ReverseMap();
        CreateMap<AuditPlan, AuditPlanByIdDTO>().ReverseMap();
        CreateMap<AuditPlan, AddAuditPlanResponseDTO>().ReverseMap();
        CreateMap<AuditPlan, AddAuditPlanCommand>().ReverseMap();
        CreateMap<AuditPlan, UpdateAuditPlanResponseDTO>().ReverseMap();
        CreateMap<AuditPlan, UpdateAuditPlanCommand>().ReverseMap();
        CreateMap<AuditPlan, DeleteAuditPlanResponseDTO>().ReverseMap();
        CreateMap<AuditPlan, DeleteAuditPlanCommand>().ReverseMap();

        CreateMap<CompositAudit, GetAuditListResponseDTO>().ReverseMap();
        // CreateMap<AuditCreation, AddAuditResponseDTO>().ReverseMap();
        CreateMap<AuditCreation, AddAuditCommand>().ReverseMap();
        CreateMap<AuditCreation, DeleteAuditCommand>().ReverseMap();
        CreateMap<CompositAudit, GetAuditByIdResponseDTO>().ReverseMap();
        CreateMap<AuditCreation, UpdateAuditCommand>().ReverseMap();
        CreateMap<AuditPlanCode, GetAuditPlanCodeListResponseDTO>().ReverseMap();

        CreateMap<CompositeTestStep, GetTestStepListQueryResponseDTO>().ReverseMap();
        CreateMap<CompositeTestStep, GetTestStepByIdDTO>().ReverseMap();
        CreateMap<TestStep, AddTestStepResponseDTO>().ReverseMap();
        CreateMap<TestStep, AddTestStepCommand>().ReverseMap();
        CreateMap<TestStep, UpdateTestStepResponseDTO>().ReverseMap();
        CreateMap<TestStep, UpdateTestStepCommand>().ReverseMap();
        CreateMap<TestStep, DeleteTestStepResponseDTO>().ReverseMap();
        CreateMap<TestStep, DeleteTestStepCommand>().ReverseMap();

        CreateMap<Branch, AddAmbsDataSyncCommandRequest>().ReverseMap();
        CreateMap<Branch, GetBranchListResponseDTO>().ReverseMap();
        CreateMap<AmbsDataSync, GetAmbsDataSyncDataByCountryAndDateInfoDTO>().ReverseMap();
        CreateMap<DataRequestQueueServiceDTO, DataRequestQueueService>().ReverseMap();
        CreateMap<CountryDTOs, Country>().ReverseMap();
        CreateMap<RiskCriteriaDTOs, RiskCriteria>().ReverseMap();
        CreateMap<CommonValueAndTypeDTO, CommonValueAndType>().ReverseMap();

        CreateMap<AuditSchedule, AddAuditScheduleCommand>().ReverseMap();

        CreateMap<AuditScheduleParticipants, AuditScheduleParticipantsCommand>().ReverseMap();
        CreateMap<AuditScheduleBranch, AuditScheduleBranchCommand>().ReverseMap();
        CreateMap<CompositAuditSchedule, GetAuditScheduleListResponseDTO>().ReverseMap();

        CreateMap<WorkPaper, WorkPaperDTO>().ReverseMap();
        CreateMap<CompositeWorkPaper, WorkPaperDTO>().ReverseMap();
        CreateMap<CompositeWorkPaper, WorkPaperByIdDTO>().ReverseMap();
        CreateMap<WorkPaper, WorkPaperByIdDTO>().ReverseMap();
        CreateMap<WorkPaper, AddWorkPaperResponseDTO>().ReverseMap();
        CreateMap<WorkPaper, AddWorkPaperCommand>().ReverseMap();
        CreateMap<WorkPaper, UpdateWorkPaperResponseDTO>().ReverseMap();
        CreateMap<WorkPaper, UpdateWorkPaperCommand>().ReverseMap();
        CreateMap<WorkPaper, DeleteWorkPaperResponseDTO>().ReverseMap();
        CreateMap<WorkPaper, DeleteWorkPaperCommand>().ReverseMap();


        CreateMap<RiskAssesmentDataManagementLog, AddRiskAssesmentDataManagementLogCommand>().ReverseMap();
        CreateMap<RiskAssesmentDataManagement, RiskAssesmentDataManagementCommand>().ReverseMap();
        CreateMap<Branch, GetBranchListResponseDTORAW>().ReverseMap();
        //CreateMap<Country, GetBranchListResponseDTORAW>().ReverseMap();

        CreateMap<Issue, GetIssueListResponseDTO>().ReverseMap();
        CreateMap<Issue, GetIssueByIdResponseDTO>().ReverseMap();

        CreateMap<Branch, GetBranchListResponseDTORAW>() // needs `Inst` -> `InstDTO` map
    .ForMember(dst => dst.CountryName, opt => opt.MapFrom(src => src.Country.Name)).ReverseMap();

        CreateMap<CommonValueAndType, SampleSizeDTO>().ReverseMap();
        CreateMap<CommonValueAndType, BranchByScheduleIdDTO>().ReverseMap();
        CreateMap<AuditScheduleBranch, BranchByScheduleIdDTO>().ReverseMap();
        CreateMap<Branch, BranchDTO>().ReverseMap();
        CreateMap<GetRiskAssesmentDataQueryDTO, CompositeRiskAssesmentData>().ReverseMap();
        CreateMap<UploadDocument, AddUploadDocumentCommand>().ReverseMap();
        CreateMap<UploadedDocumentsNotify, UploadedDocumentsNotifyCommand>().ReverseMap();
        CreateMap<UploadDocument, GetUploadedDocumentLstByRoleIdDTO>().ReverseMap();
        CreateMap<UploadedDocumentsNotify, UploadedDocumentsNotifyDTO>().ReverseMap();
        CreateMap<Document, DocumentDTOc>().ReverseMap();
        CreateMap<AuditCreationDTOs, AuditCreation>().ReverseMap();
        CreateMap<AuditScheduleParticipantsDTOs, AuditScheduleParticipants>().ReverseMap();
        CreateMap<AuditScheduleBranchs, AuditScheduleBranch>().ReverseMap();
        CreateMap<AuditTypeDTOs, AuditType>().ReverseMap();
        CreateMap<UserDTOs, User>().ReverseMap();
        CreateMap<EmployeeDTOs, Employee>().ReverseMap();
        CreateMap<GetAuditSchedulePlanIdResponseDTO, AuditSchedule>().ReverseMap();
        CreateMap<AuditType, GetAuditTypeResponseDTO>().ReverseMap();
        CreateMap<CompositAuditScheduleBranch, GetAuditScheduleBranchListResponseDTO>().ReverseMap();

        CreateMap<CompositAuditSchedule, AuditScheduleByIdDTO>().ReverseMap();
        CreateMap<AuditSchedule, AuditScheduleByIdDTO>().ReverseMap();
        CreateMap<RiskAssesmentConsolidateData, AddConsolidateDataCommand>().ReverseMap();
        CreateMap<RiskAssesmentConsolidateData, AddConsolidateDataCommandObject>().ReverseMap();
        CreateMap<RiskAssesmentConsolidateData, RiskConsolidateDataGetQueryResponseDTO>().ReverseMap();
        CreateMap<AuditSchedule, UpdateScheduleCommand>().ReverseMap();
        CreateMap<AuditSchedule, DeleteAuditScheduleCommand>().ReverseMap();
        CreateMap<TopicHead, TopicHeadByCountryIdAndDateRangeDTO>().ReverseMap();


        CreateMap<ClosingMeetingMinute, ClosingMeetingMinuteDTO>().ReverseMap();
        CreateMap<CompositeClosingMeetingMinute, ClosingMeetingMinuteDTO>().ReverseMap();
        CreateMap<AddMeetingPresent, ClosingMeetingPresent>().ReverseMap();
        CreateMap<AddMeetingApology, ClosingMeetingApology>().ReverseMap();
        CreateMap<AddMeetingSubject, ClosingMeetingSubject>().ReverseMap();
        CreateMap<CompositeClosingMeetingMinute, ClosingMeetingMinuteByIdDTO>().ReverseMap();
        CreateMap<ClosingMeetingMinute, ClosingMeetingMinuteByIdDTO>().ReverseMap();

        CreateMap<ClosingMeetingMinute, AddClosingMeetingMinuteResponseDTO>().ReverseMap();
        CreateMap<ClosingMeetingMinute, AddClosingMeetingMinuteCommand>().ReverseMap();
        CreateMap<ClosingMeetingMinute, UpdateClosingMeetingMinuteResponseDTO>().ReverseMap();
        CreateMap<ClosingMeetingMinute, UpdateClosingMeetingMinuteCommand>().ReverseMap();
        CreateMap<ClosingMeetingMinute, DeleteClosingMeetingMinuteResponseDTO>().ReverseMap();
        CreateMap<ClosingMeetingMinute, DeleteClosingMeetingMinuteCommand>().ReverseMap();
        CreateMap<WeightScore, AddweightScoreCommand>().ReverseMap();
        CreateMap<WeightScore, AddweightScoreCommandRaw>().ReverseMap();
        CreateMap<AuditScheduleConfigurationOwner, AddAuditScheduleConfigurationsOwnerCommandRaw>().ReverseMap();//
        //CreateMap<AuditScheduleConfigurationOwner, GetAllByAuditScheduledIdResponseDTO>().ReverseMap();//
        CreateMap<User, UserConfiguration>().ReverseMap();//
        CreateMap<User, UserConfiguration>().ReverseMap();//
        CreateMap<AuditScheduleConfigurationOwner, GetAllByAuditScheduledIdResponseDTO>()
        .ForMember(dst => dst.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName)).ReverseMap();
       
        CreateMap<ClosingMeetingMinute, GetClosingMeetingMinutesResponseDTO>().ReverseMap();

        CreateMap<Issue, AddIssueCommand>().ReverseMap();
        CreateMap<IssueOwner, AddIssueOwnerCommand>().ReverseMap();
        CreateMap<IssueBranch, AddIssueBranchCommand>().ReverseMap();
        CreateMap<IssueActionPlan, AddIssueActionPlanCommand>().ReverseMap();
        CreateMap<IssueActionPlanOwner, AddIssueActionOwnerListCommand>().ReverseMap();

    }
}
