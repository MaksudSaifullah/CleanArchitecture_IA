using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.common;
using Internal.Audit.Domain.Entities.Security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class UserProfileQueryRepository : QueryRepositoryBase<User>, IUserProfileQueryRepository
    {
        public UserProfileQueryRepository(string _connectionString) : base(_connectionString)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
           // email = "em.ashiq@gmail.com";
            //return await Single($"SELECT * FROM [security].[User] where Username = '{email}'", false);
            //usr.UserName ,usr.FullName,usr.ProfileImageUrl,dsg.Name,dsg.Name as DesignationName,usr.Id as userId
            var query = @"SELECT * FROM [security].[User] usr
                                    left join   security.Employee emp
                                    on usr.Id = emp.UserId
                                    left join common.Designation dsg
                                    on dsg.Id = emp.DesignationId
                                    where usr.UserName = @email";
            var parameters = new Dictionary<string, object> { { "email", email } };
            string splitters = "Id, Id";
            var data = await Get <User, Employee, Designation, User>(query, (user, employee, designation) =>
            {
                User u;
                u = user;
                u.Employee = employee;
                if (designation != null)
                {
                    u.Employee.Designation = designation;
                }
                
                return u;
            }, parameters, splitters, false);

            return data.Distinct().FirstOrDefault();
        }
    }
}
