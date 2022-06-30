using MediatR;

namespace Internal.Audit.Application.Features.UserRegistration.Commands.AddUserRegistration
{
    public class AddUserRegistrationCommand:IRequest<AddUserRegistrationResponseDTO>
    {
        public AddUserNewCommand User { get; set; }
        public AddEmployeeCommand Employee { get; set; }
        public List<AddUserRoleCommand> UserRole { get; set; }
        public List<AddUserCountryCommand> UserCountry { get; set; }
    }
    public record AddUserNewCommand
    {
        public Guid? Id { get; set; }
        public string UserName { get; set; }   
        public string Password { get; set; }       
        public bool IsEnabled { get; set; }       
        public bool IsAccountExpired { get; set; }        
        public bool IsPasswordExpired { get; set; }        
        public bool IsAccountLocked { get; set; }
    }

    public record AddEmployeeCommand 
    {       
        public Guid? UserId { get; set; }      
        public Guid DesignationId { get; set; }     
        public Guid PhotoId { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }       
        public bool IsActive { get; set; }      
      
    }
    public record AddUserRoleCommand
    {
        public Guid? UserId { get; set; }
        public Guid RoleId { get; set; }
    }
    public record AddUserCountryCommand 
    {
        public Guid CountryId { get; set; }

        public Guid? UserId { get; set; } 
        public bool IsActive { get; set; } = true;
    }
}
