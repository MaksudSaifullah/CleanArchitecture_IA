using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Countries
{
    public class CountryQueryRepository : QueryRepositoryBase<Country>, ICountryQueryRepository
    {
        public CountryQueryRepository(string _connectionString) : base(_connectionString)
        {
        }
        public async Task<IEnumerable<Country>> GetAll()
        {
            var query = @"SELECT [Id],[Name],[Code],[Remarks],[CreatedOn] FROM [common].[Country] WHERE [IsDeleted] = 0";
            return await Get(query);
        }
        public async Task<Country> GetById(Guid id)
        {
            var query = "SELECT [Id],[Name],[Code],[Remarks],[CreatedOn] FROM [common].[Country] WHERE Id = @id AND [IsDeleted] = 0";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Single(query, parameters);
        }

        public async Task<Country> GetByCode(string code)
        {
            var query = "SELECT [Id],[Name],[Code],[Remarks],[CreatedOn] FROM [common].[Country] WHERE Code = @code AND [IsDeleted] = 0";
            var parameters = new Dictionary<string, object> { { "code", code } };

            return await Single(query, parameters);
        }
    }
}
