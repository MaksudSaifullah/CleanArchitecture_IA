using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities;

public class CompositeUser : EntityBase
{
    public Guid Id { get; set; }
    //public Guid EmployeeId { get; set; }
    //public Guid CountryId { get; set; }
    //public Guid RoleId { get; set; }
    //public Guid DesignationId { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Entity { get; set; } = null!;
    public Int32 EntityCount { get; set; } = 0;
    public string EmployeeName { get; set; } = null!;
    public string UserRole { get; set; } = null!;
    public string Designation { get; set; } = null!;
    public bool IsEnabled { get; set; }
    public bool IsAccountLocked { get; set; }
    public bool IsAccountExpired { get; set; }
    public bool IsPasswordExpired { get; set; }
}
