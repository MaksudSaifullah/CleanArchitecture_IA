using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Test.MockDatas
{
    public static class ActionMockData
    {
        public static List<AuditAction> actionList = new List<AuditAction>();

        public static List<AuditAction> GetActionsData()
        {
            return actionList;
        }


        public static void AddActionStatic()
        {
            if (actionList.Count <= 3)
            {
                actionList.Add(new AuditAction
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

                    Name = "EDIT",
                    DisplayName = "Edit"
                    

                });
                actionList.Add(new AuditAction
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

                    Name = "VIEW",
                    DisplayName = "View"

                });
                actionList.Add(new AuditAction
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

                    Name = "DELETE",
                    DisplayName = "Delete"

                });
            }

        }

        public static void ResetActionStatic()
        {
            actionList.Clear();
        }
    }
}
