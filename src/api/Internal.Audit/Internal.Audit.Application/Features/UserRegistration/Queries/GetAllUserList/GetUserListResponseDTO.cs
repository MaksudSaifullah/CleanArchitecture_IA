using Internal.Audit.Domain.Entities.security;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserRegistration.Queries.GetAllUserList
{
    public class GetUserListResponseDTO
    {
        public Guid Id { get; set; }
       
        public string UserName { get; set; } = null!;
       
        public string Password { get; set; } = null!;

       
        public bool IsEnabled { get; set; }
        
        public bool IsAccountExpired { get; set; }
      
        public bool IsPasswordExpired { get; set; }
       
        public bool IsAccountLocked { get; set; }


        public virtual ICollection<UserCountry> UserCountries { get; set; } = null!;
        public virtual ICollection<UserRole> UserRoles { get; set; } = null!;
        public virtual Employee Employee { get; set; }
    }
}
