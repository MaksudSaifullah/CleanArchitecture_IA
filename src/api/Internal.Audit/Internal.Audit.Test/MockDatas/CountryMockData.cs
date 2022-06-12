using Internal.Audit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Test.MockDatas
{
    public static class CountryMockData
    {
        public static List<Country> countryList = new List<Country>();

        public static List<Country> updatecountryList = new List<Country>();
        public static List<Country> deletecountryList = new List<Country>();

        public static List<Country> GetCountriesData()
        {
            return countryList;
        }
        public static List<Country> updateCountriesData()
        {
            return updatecountryList;
        }
        public static List<Country> deleteCountriesData()
        {
            return deletecountryList;
        }

        public static void AddCountryStatic()
        {
            if (countryList.Count <= 3)
            {
                countryList.Add(new Country
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

                    Name = "Bangladesh",
                    Code = "BD",
                    Remarks = ""

                });
                countryList.Add(new Country
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

                    Name = "Nepal",
                    Code = "NP",
                    Remarks = ""

                });
                countryList.Add(new Country
                {
                    Id = new Guid("73C94EF7-4B6D-4D86-BAFA-67252CCC2A8A"),
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "",
                    UpdatedOn = null,
                    ReviewedBy = "",
                    ReviewedOn = null,
                    ApprovedBy = "",
                    ApprovedOn = null,
                    IsDeleted = false,

                    Name = "Bhutan",
                    Code = "BT",
                    Remarks = ""

                });
            }
           
        }
        public static void deleteAddCountryStatic()
        {
            deletecountryList.Add(new Country
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

                Name = "Bangladesh",
                Code = "BD",
                Remarks = ""
            });
            deletecountryList.Add(new Country
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

                Name = "Nepal",
                Code = "NP",
                Remarks = ""
            });
            deletecountryList.Add(new Country
            {
                Id = new Guid("73C94EF7-4B6D-4D86-BAFA-67252CCC2A8A"),
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now,
                UpdatedBy = "",
                UpdatedOn = null,
                ReviewedBy = "",
                ReviewedOn = null,
                ApprovedBy = "",
                ApprovedOn = null,
                IsDeleted = false,

                Name = "Bhutan",
                Code = "BT",
                Remarks = ""
            });
        }
        public static void updateAddCountryStatic()
        {
            updatecountryList.Add(new Country
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

                Name = "Bangladesh",
                Code = "BD",
                Remarks = ""
            });
            updatecountryList.Add(new Country
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

                Name = "Nepal",
                Code = "NP",
                Remarks = ""
            });
            updatecountryList.Add(new Country
            {
                Id = new Guid("73C94EF7-4B6D-4D86-BAFA-67252CCC2A8A"),
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now,
                UpdatedBy = "",
                UpdatedOn = null,
                ReviewedBy = "",
                ReviewedOn = null,
                ApprovedBy = "",
                ApprovedOn = null,
                IsDeleted = false,

                Name = "Bhutan",
                Code = "BT",
                Remarks = ""
            });
        }
        public static void ResetCountryStatic()
        {
            countryList.Clear();
        }
    }
}
