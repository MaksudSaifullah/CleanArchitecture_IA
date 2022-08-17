using Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes;
using Internal.Audit.Domain.Entities.Config;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.CommonValueAndTypes
{
    public class CommonValueAndTypeQueryRepository : QueryRepositoryBase<CommonValueAndType>, ICommonValueAndTypeQueryRepository
    {
        public CommonValueAndTypeQueryRepository(string _connectionString) : base(_connectionString)
        {
        }

        public async Task<CommonValueAndType> GetByIDCreationValue(int value)
        {
            var query = "SELECT [Text] FROM [Config].[CommonValueAndType] WHERE [Type] = '" + "IDCREATION" + "' AND [Value] = "+value;
            return await Single(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetCommonValueType(string type)
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = '" + type + "' AND [IsDeleted] = 0";
            return await Get(query);
        }
        public async Task<IEnumerable<CommonValueAndType>> GetByControlActivityId(Guid id)
        {
            var query = @"select cf.Id, cf.Type, cf.SubType, cf.Value, cf.Text from Config.CommonValueAndType nca
                          inner join Config.CommonValueAndType cf on nca.Value = cf.SubType
				           WHERE nca.[Id] = @id AND nca.IsDeleted = 0 and cf.Type = 'CONTROLFREQUENCY'";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Get(query, parameters);
        }
        public async Task<IEnumerable<CommonValueAndType>> GetByControlFrequencyId(Guid id)
        {
            var query = @"select ss.Id, ss.Type, ss.SubType, ss.Value, ss.Text from Config.CommonValueAndType cf
                          inner join Config.CommonValueAndType ss on cf.Value = ss.SubType
				           WHERE cf.[Id] = @id AND cf.IsDeleted = 0 and ss.Type = 'SAMPLESIZE'";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Get(query, parameters);
        }
    }
}
