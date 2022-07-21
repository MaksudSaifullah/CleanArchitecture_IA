using Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes;
using Internal.Audit.Domain.Entities.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.CommonValueAndTypes
{
    public class CommonValueAndTypeQueryRepository : QueryRepositoryBase<CommonValueAndType>, ICommonValueAndTypeQueryRepository
    {
        public CommonValueAndTypeQueryRepository(string _connectionString) : base(_connectionString)
        {
        }       

        public async Task<IEnumerable<CommonValueAndType>> GetCommonValueType(string type)
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = '" + type + "' AND [IsDeleted] = 0";
            return await Get(query);
        }
    }
}
