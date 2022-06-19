using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Test.MockDatas
{
    public static class FeatureMockData
    {
        public static List<AuditFeature> featureList = new List<AuditFeature>();

        public static List<AuditFeature> GetFeaturesData()
        {
            return featureList;
        }


        public static void AddFeatureStatic()
        {
            if (featureList.Count <= 3)
            {
                featureList.Add(new AuditFeature
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

                    Name = "RISKASSESMENT",
                    DisplayName = "Risk Assesment"


                });
                featureList.Add(new AuditFeature
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

                    Name = "RISKPROFILE",
                    DisplayName = "Risk Profile"

                });
                featureList.Add(new AuditFeature
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

                    Name = "PLANCREATION",
                    DisplayName = "Plan Creation"

                });
            }

        }

        public static void ResetFeatureStatic()
        {
            featureList.Clear();
        }
    }
}
