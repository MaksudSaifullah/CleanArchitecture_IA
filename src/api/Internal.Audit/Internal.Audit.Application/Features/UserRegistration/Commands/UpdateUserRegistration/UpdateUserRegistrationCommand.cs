using MediatR;

namespace Internal.Audit.Application.Features.UserRegistration.Commands.UpdateUserRegistration
{
    public class UpdateUserRegistrationCommand:IRequest<UpdateUserRegistrationResponseDTO>
    {
        public AddUserUpdateCommand User { get; set; }
        public AddEmployeeUpdateCommand Employee { get; set; }
        public List<AddUserRoleUpdateCommand> UserRole { get; set; }
        public List<AddUserCountryUpdateCommand> UserCountry { get; set; }
    }
    public record AddUserUpdateCommand
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsAccountExpired { get; set; }
        public bool IsPasswordExpired { get; set; }
        public bool IsAccountLocked { get; set; }
    }

    public record AddEmployeeUpdateCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DesignationId { get; set; }
        public Guid PhotoId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

    }
    public record AddUserRoleUpdateCommand
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
    public record AddUserCountryUpdateCommand
    {
        public Guid Id { get; set; }

        public Guid CountryId { get; set; }

        public Guid UserId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
