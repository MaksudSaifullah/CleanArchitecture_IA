
using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.Common;
using Internal.Audit.Domain.Entities.config;
using Internal.Audit.Domain.Entities.Config;
using Internal.Audit.Domain.Entities.security;
using Internal.Audit.Domain.Entities.Security;

namespace Internal.Audit.Infrastructure.Persistent;

public class InternalAuditContextSeed
{
    public static async Task SeedAsync(InternalAuditContext context)
    {
        if (!context.Users.Any())
        {
            context.Users.AddRange(GetSeedUsers());
            await context.SaveChangesAsync();
        }
        if (!context.DocumentSources.Any())
        {
            context.DocumentSources.AddRange(GetInitialDocumentSource());
            await context.SaveChangesAsync();
        }
        if (!context.CommonValueAndTypes.Any())
        {
            context.CommonValueAndTypes.AddRange(GetInitialCommonvalueAndType());
            await context.SaveChangesAsync();
        }
        if (!context.EmailTypes.Any())
        {
            context.EmailTypes.AddRange(GetSeedEmailTypes());
            await context.SaveChangesAsync();
        }
        if (context.CommonValueAndTypes.Count(x => x.Type == "RISKRATINGNAME") == 3)
        {
            context.CommonValueAndTypes.AddRange(RiskRatingNewTypes());
            await context.SaveChangesAsync();
        }


        if (!context.PasswordPolicies.Any())
        {
            context.PasswordPolicies.AddRange(GetSeedPasswordPolicy());
            await context.SaveChangesAsync();
        }
        if (!context.SessionPolicies.Any())
        {
            context.SessionPolicies.AddRange(GetSeedSessionPolicy());
            await context.SaveChangesAsync();
        }
        if (!context.UserLockingPolicies.Any())
        {
            context.UserLockingPolicies.AddRange(GetSeedUserLockingPolicy());
            await context.SaveChangesAsync();
        }
        if(!context.CommonValueAndTypes.Where(x=>x.Type== "RISKASSESMENT").Any())
        {
            context.CommonValueAndTypes.AddRange(RiskAssesmentType());
            await context.SaveChangesAsync();
        }
        if (!context.AuditModule.Any())
        {
            context.AuditModule.AddRange(AuditModuleAdd());
            await context.SaveChangesAsync();
        }
        if (context.DocumentSources.ToList().Count()==5)
        {
            context.DocumentSources.AddRange(GetDocumentSourceNewAdded());
            await context.SaveChangesAsync();
        }
    }



    private static IEnumerable<User> GetSeedUsers()
    {
        return new List<User>
        {
            new User
            {
                UserName = "Admin", Password = "@dmin123", IsPasswordExpired = false, IsEnabled = true, IsDeleted = false,
                IsAccountExpired = false, IsAccountLocked = false
            }

        };
    }

    private static IEnumerable<PasswordPolicy> GetSeedPasswordPolicy()
    {
        return new List<PasswordPolicy>
        {
            new PasswordPolicy
            {
                MinLength = 8, MaxLength = 20,
                IsAlphabetMandatory = true, IsNumberMandatory = true, IsSpecialCharsMandatory = true,
                AlphabetLength = 2, NumericLength = 1, SpecialCharsLength = 1,
                IsPasswordChangeForcedOnFirstLogin = true, IsPasswordResetForcedPeriodically = true,
                ForcePasswordResetDays = 100, NotifyPasswordResetDays = 90,
                EffectiveFrom = new DateTime(2022, 01, 01), EffectiveTo = null
            }

        };
    }
    private static IEnumerable<SessionPolicy> GetSeedSessionPolicy()
    {
        return new List<SessionPolicy>
        {
            new SessionPolicy
            {
                IsEnabled = true, Duration = 500,
                EffectiveFrom = new DateTime(2022, 01, 01), EffectiveTo = null
            }
        };
    }
    private static IEnumerable<UserLockingPolicy> GetSeedUserLockingPolicy()
    {
        return new List<UserLockingPolicy>
        {
            new UserLockingPolicy
            {
                IsLockedOnNoLoginActivity = true, NoLoginActivityDays = 100, LockedOnFailedLoginAttempts = true,
                NumberOfFailedLoginAttempts = 10, FailedLoginAttemptsDuration = 100, FailedLoginLockedDuration = 120,
                UnlockedOnByAdmin = true, UnlockedOnByAdminDuration = 120,
                EffectiveFrom = new DateTime(2022, 01, 01), EffectiveTo = null
            }
        };
    }
    private static IEnumerable<EmailType> GetSeedEmailTypes()
    {
        return new List<EmailType>
        {
            new EmailType
            {
                Name = "Commencement Letter (Branch Audit)", Status = true, CreatedBy="system",CreatedOn=DateTime.Now, IsDeleted = false
            },
            new EmailType
            {
                Name = "Commencement Letter (Process & Control)", Status = true, CreatedBy="system",CreatedOn=DateTime.Now, IsDeleted = false
            },

        };
    }
    private static IEnumerable<DocumentSource> GetInitialDocumentSource()
    {
        return new List<DocumentSource>
        {
            new DocumentSource
            {
               Name ="Profile_Picture",CreatedBy="system",CreatedOn=DateTime.Now
            },
            new DocumentSource
            {
               Name ="Approval_Evidence",CreatedBy="system",CreatedOn=DateTime.Now
            },
             new DocumentSource
            {
               Name ="Review_Evidence",CreatedBy="system",CreatedOn=DateTime.Now
            },
              new DocumentSource
            {
               Name ="Testing_Sheets",CreatedBy="system",CreatedOn=DateTime.Now
            },
               new DocumentSource
            {
               Name ="Evidence_Details",CreatedBy="system",CreatedOn=DateTime.Now
            },

        };
    }
    private static IEnumerable<DocumentSource> GetDocumentSourceNewAdded()
    {
        return new List<DocumentSource>
        {
            new DocumentSource
            {
               Name ="Upload_All_Document",CreatedBy="system",CreatedOn=DateTime.Now
            },
            

        };
    }
    #region CommonvalueDataInsert
    private static IEnumerable<CommonValueAndType> GetInitialCommonvalueAndType()
    {
        return new List<CommonValueAndType>
        {
            new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="CONTROLFREQUENCY",SubType="1",Value=1,Text="Annually",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="CONTROLFREQUENCY",SubType="1",Value=2,Text="quarterly",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="CONTROLFREQUENCY",SubType="1",Value=3,Text="monthly",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="CONTROLFREQUENCY",SubType="1",Value=4,Text="weekly",SortOrder=40,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="CONTROLFREQUENCY",SubType="1",Value=5,Text="daily",SortOrder=50,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="CONTROLFREQUENCY",SubType="1",Value=6,Text="multiple times per day",SortOrder=60,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="CONTROLFREQUENCY",SubType="2",Value=7,Text="1 to 4",SortOrder=70,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="CONTROLFREQUENCY",SubType="2",Value=8,Text="5 to 12",SortOrder=80,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="CONTROLFREQUENCY",SubType="2",Value=9,Text="13 to 52",SortOrder=90,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="CONTROLFREQUENCY",SubType="2",Value=10,Text="53 to 260",SortOrder=100,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="CONTROLFREQUENCY",SubType="2",Value=11,Text="greater than 260",SortOrder=110,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="EMAILTYPE",SubType="",Value=1,Text="Commencement Letter (Branch Audit)",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="EMAILTYPE",SubType="",Value=2,Text="Commencement Letter (Process & Control Audit)",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="EMAILTYPE",SubType="",Value=3,Text="ToR",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="LEVELOFLIKELIHOOD",SubType="",Value=1,Text="Almost Certain",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="LEVELOFLIKELIHOOD",SubType="",Value=2,Text="Likely",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="LEVELOFLIKELIHOOD",SubType="",Value=3,Text="Moderate",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="LEVELOFLIKELIHOOD",SubType="",Value=4,Text="Unlikely",SortOrder=40,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="LEVELOFLIKELIHOOD",SubType="",Value=5,Text="Rare",SortOrder=50,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="LEVELOFIMPACT",SubType="",Value=1,Text="Insignificant",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="LEVELOFIMPACT",SubType="",Value=2,Text="Minor",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="LEVELOFIMPACT",SubType="",Value=3,Text="Moderate",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="LEVELOFIMPACT",SubType="",Value=4,Text="Major",SortOrder=40,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATING",SubType="",Value=1,Text="High",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATING",SubType="",Value=2,Text="Low",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATING",SubType="",Value=3,Text="Moderate",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATING",SubType="",Value=4,Text="Significant",SortOrder=40,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATING",SubType="",Value=5,Text="Extreme",SortOrder=50,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATINGNAME",SubType="",Value=1,Text="Overdue",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATINGNAME",SubType="",Value=2,Text="Collection",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATINGNAME",SubType="",Value=3,Text="Disbursement",SortOrder=30,
            }
            ,new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATINGNAME",SubType="",Value=4,Text="Lo productivity",SortOrder=40,
            }
            ,new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATINGNAME",SubType="",Value=5,Text="StaffTurn Over",SortOrder=50,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATINGNAME",SubType="",Value=6,Text="Fraud ",SortOrder=60,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="LOPRODUCTIVITY",SubType="",Value=1,Text="Not Available",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="LOPRODUCTIVITY",SubType="",Value=2,Text="Strong",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="LOPRODUCTIVITY",SubType="",Value=3,Text="Good",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="LOPRODUCTIVITY",SubType="",Value=4,Text="Bad",SortOrder=40,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="YEAR",SubType="",Value=1,Text="2022",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="YEAR",SubType="",Value=2,Text="2020",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="YEAR",SubType="",Value=3,Text="2020",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="YEAR",SubType="",Value=4,Text="2020",SortOrder=40,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="YEAR",SubType="",Value=5,Text="2020",SortOrder=50,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="YEAR",SubType="",Value=6,Text="2020",SortOrder=60,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="YEAR",SubType="",Value=7,Text="2020",SortOrder=70,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="YEAR",SubType="",Value=8,Text="2020",SortOrder=80,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="YEAR",SubType="",Value=9,Text="2020",SortOrder=90,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLEDMONTH",SubType="",Value=1,Text="January",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLEDMONTH",SubType="",Value=2,Text="February",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLEDMONTH",SubType="",Value=3,Text="March",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLEDMONTH",SubType="",Value=4,Text="April",SortOrder=40,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLEDMONTH",SubType="",Value=5,Text="May",SortOrder=50,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLEDMONTH",SubType="",Value=6,Text="June",SortOrder=60,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLEDMONTH",SubType="",Value=7,Text="July",SortOrder=70,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLEDMONTH",SubType="",Value=8,Text="August",SortOrder=80,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLEDMONTH",SubType="",Value=9,Text="September",SortOrder=90,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLEDMONTH",SubType="",Value=10,Text="October",SortOrder=100,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLEDMONTH",SubType="",Value=11,Text="November",SortOrder=110,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLEDMONTH",SubType="",Value=12,Text="December",SortOrder=120,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLESELECTIONMETHOD",SubType="",Value=1,Text="Random",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLESELECTIONMETHOD",SubType="",Value=2,Text="Judgmental",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="SAMPLESELECTIONMETHOD",SubType="",Value=3,Text="Haphazard",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="NATUREOFCONTROLACTIVITY",SubType="",Value=1,Text="Cyclic Controls",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="NATUREOFCONTROLACTIVITY",SubType="",Value=2,Text="Ad Hoc Controls",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="NATUREOFCONTROLACTIVITY",SubType="",Value=3,Text="Automated Controls",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="ISSUESTATUS",SubType="",Value=1,Text="Pending Validation",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="ISSUESTATUS",SubType="",Value=2,Text="Open",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="ISSUESTATUS",SubType="",Value=3,Text="Closed",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="ISSUESTATUS",SubType="",Value=4,Text="Closed & Validated",SortOrder=40,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITCONDUCTED",SubType="",Value=1,Text="Quarter-1",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITCONDUCTED",SubType="",Value=2,Text="Quarter-2",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITCONDUCTED",SubType="",Value=3,Text="Quarter-3",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITCONDUCTED",SubType="",Value=4,Text="Quarter-4",SortOrder=40,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="DETESTCONCLUSION",SubType="",Value=1,Text="Pass",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="DETESTCONCLUSION",SubType="",Value=2,Text="Fail",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="YESNO",SubType="",Value=1,Text="Yes",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="YESNO",SubType="",Value=2,Text="No",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITTYPE",SubType="",Value=1,Text="Branch Audit",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITTYPE",SubType="",Value=2,Text="Process and Controll Audit",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITFREQUENCY",SubType="",Value=1,Text="Once in a year",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITFREQUENCY",SubType="",Value=2,Text="Twice in a Year",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITFREQUENCY",SubType="",Value=3,Text="Thrice in a Year",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITFREQUENCY",SubType="",Value=4,Text="Once in two Year",SortOrder=40,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITSCORE",SubType="",Value=1,Text="1",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITSCORE",SubType="",Value=2,Text="2",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITSCORE",SubType="",Value=3,Text="3",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=1,Text="RA- Risk Assesments",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=2,Text="PL- Generate A Plan",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=3,Text="SUBPL- Create Sub Plan",SortOrder=30,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=4,Text="PNCAudit- New Process and Control Audit",SortOrder=40,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=5,Text="DET- DE Test Script",SortOrder=50,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=6,Text="RCDDE- RCD Design(DE)",SortOrder=60,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=7,Text="TOR- Terms Of Reference",SortOrder=70,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=8,Text="OPNMT- Opening Meeting Minutes",SortOrder=80,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=9,Text="OET- OE Test Script",SortOrder=90,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=10,Text="RCDOE- RCD OE",SortOrder=100,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=11,Text="CLSMT- Closing Meeting Minutes",SortOrder=110,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=12,Text="Issue- Issue",SortOrder=120,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=13,Text="MAP- Action Plan",SortOrder=130,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=14,Text="DraftReport- Draft Report",SortOrder=140,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=15,Text="FinalReport- Final Report",SortOrder=130,
            }
            ,new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="IDCREATION",SubType="",Value=16,Text="BAudit- New Branch Audit",SortOrder=140,
            },
            new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="DATAPULLREQUEST",SubType="",Value=1,Text="OverDue",SortOrder=10,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="DATAPULLREQUEST",SubType="",Value=2,Text="Collection",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="DATAPULLREQUEST",SubType="",Value=3,Text="Disburse",SortOrder=10,
            },
            new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITSCHEDULELISTTYPE",SubType="",Value=1,Text="NameOfApprover",SortOrder=10,
            },
            new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITSCHEDULELISTTYPE",SubType="",Value=2,Text="NameOfTeamLeader",SortOrder=20,
            },
            new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="AUDITSCHEDULELISTTYPE",SubType="",Value=3,Text="NameOfAuditor",SortOrder=30,
            },

        };
    }
    #endregion

    private static IEnumerable<CommonValueAndType> RiskRatingNewTypes()
    {
        return new List<CommonValueAndType>
        {
            new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATINGNAME",SubType="",Value=4,Text="Lo productivity",SortOrder=40,
            }
            ,new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATINGNAME",SubType="",Value=5,Text="StaffTurn Over",SortOrder=50,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKRATINGNAME",SubType="",Value=6,Text="Fraud ",SortOrder=60,
            }
        };
    }

    private static IEnumerable<CommonValueAndType> RiskAssesmentType()
    {
        return new List<CommonValueAndType>
        {
            new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKASSESMENT",SubType="",Value=1,Text="Low",SortOrder=10,
            }
            ,new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKASSESMENT",SubType="",Value=2,Text="Medium",SortOrder=20,
            },new CommonValueAndType
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Type="RISKASSESMENT",SubType="",Value=3,Text="High ",SortOrder=30,
            }
        };
    }
    private static IEnumerable<AuditModule> AuditModuleAdd()
    {
        return new List<AuditModule>
        {
            new AuditModule
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Name="COMMON",DisplayName="Common Configuration"
            }
            ,new AuditModule
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Name="SECURITY",DisplayName="Security"
            },new AuditModule
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Name="BA",DisplayName="Branch Audit"
            }
            ,new AuditModule
            {
                IsActive = true,CreatedBy="admin",CreatedOn=DateTime.Now,Name="PA",DisplayName="Process & Control Audit"
            }
        };
    }
}
