using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Test.MockDatas
{
    public static class AuditModuleMockData
    {
        public static List<AuditModule> moduleList = new List<AuditModule>();

        public static List<AuditModule> GetModulesData()
        {
            return moduleList;
        }


        public static void AddModuleStatic()
        {
            if (moduleList.Count <= 3)
            {
                moduleList.Add(new AuditModule
                {
                    Id = new Guid("A81CFECC-0BEB-EC11-B3B0-00155D610B18"),
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "",
                    UpdatedOn = null,
                    ReviewedBy = "",
                    ReviewedOn = null,
                    ApprovedBy = "",
                    ApprovedOn = null,
                    IsDeleted = false,

                    Name = "COMMON",
                    DisplayName = "Common Configuration"


                });
                moduleList.Add(new AuditModule
                {
                    Id = new Guid("496BE48B-E21A-47D5-AB85-D1A0D4EDC744"),
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "",
                    UpdatedOn = null,
                    ReviewedBy = "",
                    ReviewedOn = null,
                    ApprovedBy = "",
                    ApprovedOn = null,
                    IsDeleted = false,

                    Name = "SECURITY",
                    DisplayName = "Security"

                });
                moduleList.Add(new AuditModule
                {
                    Id = new Guid("6AAEAAB8-0CEB-EC11-B3B0-00155D610B18"),
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "",
                    UpdatedOn = null,
                    ReviewedBy = "",
                    ReviewedOn = null,
                    ApprovedBy = "",
                    ApprovedOn = null,
                    IsDeleted = false,

                    Name = "BA",
                    DisplayName = "Branch Audit"

                });
            }

        }

        public static void ResetModuleStatic()
        {
            moduleList.Clear();
        }
    }
}

