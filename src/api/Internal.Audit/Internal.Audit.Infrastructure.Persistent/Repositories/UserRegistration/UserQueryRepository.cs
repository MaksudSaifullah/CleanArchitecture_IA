using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.security;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class UserQueryRepository : QueryRepositoryBase<User>, IUserQueryRepository
    {
        public UserQueryRepository(string _connectionString) : base(_connectionString)
        {
        }

        public async Task<User> Get(long id)
        {
            var query = "SELECT * FROM [dbo].[Users] WHERE Id = @id";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Single(query, parameters);
        }

        public async Task<IEnumerable<User>> GetAll(bool activeOnly)
        {
            var query = "SELECT * FROM [dbo].[Users] WHERE [Status] = @status";
            var parameters = new Dictionary<string, object> { { "status", activeOnly } };

            return await Get(query, parameters);
        }

        public async Task<IEnumerable<User>> GetAllUserList()
        {
            var query = @"select * from [security].[User] usr  inner JOIN [security].[UserCountry] usercountry
                          on usr.Id=usercountry.UserId
                          INNER join  [security].[UserRole] userole
                          on userole.UserId=usercountry.UserId
                          INNER join [security].[Employee] emp
                          on emp.UserId=usercountry.UserId
                          Where  usr.[IsDeleted]=0";
            string splitters = "Id, Id, Id";
            var parameters = new Dictionary<string, object> {  };
            var userDictionary = new Dictionary<Guid, User>();
            var countryDictionary = new Dictionary<Guid, UserCountry>();
            var roleDictionary = new Dictionary<Guid, UserRole>();
            var data = await Get<User, UserCountry, UserRole, Employee, User>(query,(user, userCountry, role, employee) =>
            {

                User u;
                if (!userDictionary.ContainsKey(user.Id))
                {
                    userDictionary.Add(user.Id, user);
                    u = user;
                    u.UserCountries = new List<UserCountry>();
                    u.UserRoles = new List<UserRole>();
                }
                else
                {
                    u= userDictionary[user.Id];
                }
                u.Employee=employee;
                if(!countryDictionary.ContainsKey(userCountry.Id))
                {
                    countryDictionary.Add(userCountry.Id, userCountry);
                    u.UserCountries.Add(userCountry);
                }
                if (!roleDictionary.ContainsKey(role.Id))
                {
                    roleDictionary.Add(role.Id, role);
                    u.UserRoles.Add(role);
                }

                return u;
            }, parameters, splitters, false);

            return data.Distinct();
        }

        public async Task<User> GetAllUserListById(Guid userId)
        {
            var query = @"select * from [security].[User] usr  inner JOIN [security].[UserCountry] usercountry
                          on usr.Id=usercountry.UserId
                          INNER join  [security].[UserRole] userole
                          on userole.UserId=usercountry.UserId
                          INNER join [security].[Employee] emp
                          on emp.UserId=usercountry.UserId
                          where  usr.Id =@userId and usr.[IsDeleted]=0";
            string splitters = "Id, Id, Id";
            var parameters = new Dictionary<string, object> { { "userId", userId } };
            var orderDictionary = new Dictionary<Guid, User>();
            var countryDictionary = new Dictionary<Guid, UserCountry>();
            var roleDictionary = new Dictionary<Guid, UserRole>();
            var data = await Get<User, UserCountry, UserRole, Employee, User>(query, (user, userCountry, role, employee) =>
            {

                User u;
                if (!orderDictionary.ContainsKey(user.Id))
                {
                    orderDictionary.Add(user.Id, user);
                    u = user;
                    u.UserCountries = new List<UserCountry>();
                    u.UserRoles = new List<UserRole>();
                }
                else
                {
                    u = orderDictionary[user.Id];
                }
                u.Employee = employee;
                if (!countryDictionary.ContainsKey(userCountry.Id))
                {
                    countryDictionary.Add(userCountry.Id, userCountry);
                    u.UserCountries.Add(userCountry);
                }
                if (!roleDictionary.ContainsKey(role.Id))
                {
                    roleDictionary.Add(role.Id, role);
                    u.UserRoles.Add(role);
                }

                return u;
            }, parameters, splitters, false);

            User? user = data.Distinct().FirstOrDefault();
            return user;
        }

        public async Task<User> GetByUserEmail(string email, string password)
        {
            var query = "SELECT * FROM [Security].[User] WHERE [Username] = @email AND [Password] = @password AND IsAccountLocked = 0";
            var parameters = new Dictionary<string, object> { { "email", email }, { "password", password } };

            return await Single(query, parameters);
        }

        public async Task<User> GetByUserEmail(string email)
        {
            var query = $@"SELECT u.* FROM [security].[User] u
                                   INNER JOIN security.Employee e on u.Id = e.UserId
                                   where e.Email = @email";

            var parameters = new Dictionary<string, object> { { "email", email } };

            return await Single(query, parameters);
        }
    }
}
