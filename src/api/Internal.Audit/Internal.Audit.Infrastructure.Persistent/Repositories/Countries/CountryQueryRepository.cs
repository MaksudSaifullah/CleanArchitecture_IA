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
        public async Task<(long, IEnumerable<Country>)> GetAll(int pageSize, int pageNumber)
        {

            var query = "EXEC [dbo].[GetCountryListProcedure] @pageSize,@pageNumber";
            var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber } };
            return await GetWithPagingInfo(query, parameters, false);

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
