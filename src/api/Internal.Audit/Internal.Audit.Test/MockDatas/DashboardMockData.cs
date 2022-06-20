using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Test.MockDatas
{
    public static class DashboardMockData
    {
        public static List<DashBoardBase> dashboardList = new List<DashBoardBase>();

        public static List<DashBoardBase> updatedashboardList = new List<DashBoardBase>();

        public static List<DashBoardBase> GetDashBoardsData()
        {
            return dashboardList;
        }
        public static List<DashBoardBase> updateDashBoardsData()
        {
            return updatedashboardList;
        }

        public static void AddDashboardStatic()
        {
            if (dashboardList.Count <= 3)
            {
                dashboardList.Add(new DashBoardBase
                {
                    Id = new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"),
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "",
                    UpdatedOn = null,
                    ReviewedBy = "",
                    ReviewedOn = null,
                    ApprovedBy = "",
                    ApprovedOn = null,
                    IsDeleted = false,

                    Name = "Country Dashboard",
                    Status = true

                });
                dashboardList.Add(new DashBoardBase
                {
                    Id = new Guid("0AD5E105-81EC-EC11-B3B0-00155D610B18"),
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "",
                    UpdatedOn = null,
                    ReviewedBy = "",
                    ReviewedOn = null,
                    ApprovedBy = "",
                    ApprovedOn = null,
                    IsDeleted = false,

                    Name = "My Dashboard",
                    Status = true

                });
                dashboardList.Add(new DashBoardBase
                {
                    Id = new Guid("9703592C-81EC-EC11-B3B0-00155D610B18"),
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "",
                    UpdatedOn = null,
                    ReviewedBy = "",
                    ReviewedOn = null,
                    ApprovedBy = "",
                    ApprovedOn = null,
                    IsDeleted = false,

                    Name = "Your Dashboard",
                    Status = true

                });
            }

        }
      
        public static void updateAddDashboardStatic()
        {
            updatedashboardList.Add(new DashBoardBase
            {
                Id = new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"),
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now,
                UpdatedBy = "",
                UpdatedOn = null,
                ReviewedBy = "",
                ReviewedOn = null,
                ApprovedBy = "",
                ApprovedOn = null,
                IsDeleted = false,

                Name = "Country Dashboard",
                Status = true
            });
            updatedashboardList.Add(new DashBoardBase
            {
                Id = new Guid("0AD5E105-81EC-EC11-B3B0-00155D610B18"),
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now,
                UpdatedBy = "",
                UpdatedOn = null,
                ReviewedBy = "",
                ReviewedOn = null,
                ApprovedBy = "",
                ApprovedOn = null,
                IsDeleted = false,

                Name = "My Dashboard",
                Status = true
            });
            updatedashboardList.Add(new DashBoardBase
            {
                Id = new Guid("9703592C-81EC-EC11-B3B0-00155D610B18"),
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now,
                UpdatedBy = "",
                UpdatedOn = null,
                ReviewedBy = "",
                ReviewedOn = null,
                ApprovedBy = "",
                ApprovedOn = null,
                IsDeleted = false,

                Name = "Your Dashboard",
                Status = true
            });
        }
        public static void ResetDashboardStatic()
        {
            dashboardList.Clear();
        }
    }
}
