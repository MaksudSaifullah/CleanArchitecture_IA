using Internal.Audit.Domain.Entities.common;
using System;
using System.Collections.Generic;

namespace Internal.Audit.Test.MockDatas;
public class DesignationMockData
{
    public static List<Designation> designationList = new List<Designation>();

    public static List<Designation> updateDesignationList = new List<Designation>();

    public static List<Designation> GetDesignationList()
    {
        return designationList;
    }
    public static List<Designation> updateDesignation()
    {
        return updateDesignationList;
    }
    public static void AddDesignationStatic()
    {
        if (designationList.Count <= 3)
        {
            designationList.Add(new Designation
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

                Name = "IT Officer",
                Description = "IT Officer Designation Added",
                IsActive = true

            });
            designationList.Add(new Designation
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

                Name = "Cashier",
                Description = "Ccashier designation added",
                IsActive = true

            });
            designationList.Add(new Designation
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

                Name = "Accountants",
                Description = "Accountants designation added",
                IsActive = true

            });
        }

    }
    public static void updateDesignationStatic()
    {
        updateDesignationList.Add(new Designation
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

            Name = "IT Officer",
            Description = "IT Officer Designation Updated",
            IsActive = true
        });
        updateDesignationList.Add(new Designation
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

            Name = "Cashier",
            Description = "Cashier designation updated",
            IsActive = true
        });
        updateDesignationList.Add(new Designation
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

            Name = "Accountants",
            Description = "Accountants designation updated",
            IsActive = true
        });
    }
    public static void ResetDesignationStatic()
    {
        updateDesignationList.Clear();
    }
}