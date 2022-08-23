using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserRegistration.Queries.GetUserProfile
{
    public class UserProfileQueryResponseDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string DesignationName { get; set; } = string.Empty;

    }
}
