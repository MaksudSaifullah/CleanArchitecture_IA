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

        public async Task<IEnumerable<CommonValueAndType>> GetAllAuditConducted()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'AUDITCONDUCTED' AND [IsDeleted] = 0";
            return await Get(query);
        }
        public async Task<IEnumerable<CommonValueAndType>> GetAllControlFrequency()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'CONTROLFREQUENCY' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetAllDetestConclusion()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'DETESTCONCLUSION' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetAllEMailType()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'EMAILTYPE' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetAllIssueStatus()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'ISSUESTATUS' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetAllLevelOfImpact()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'LEVELOFIMPACT' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetAllLevelOfLikelihood()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'LEVELOFLIKELIHOOD' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetAllLOProductivity()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'LOPRODUCTIVITY' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetAllNatureOfControlActivity()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'NATUREOFCONTROLACTIVITY' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetAllRiskRating()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'RISKRATING' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetAllRiskRatingName()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'RISKRATINGNAME' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetAllSampledMonth()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'SAMPLEDMONTH' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetAllSampleSelectionMethod()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'SAMPLESELECTIONMETHOD' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetAllYear()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'YEAR' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetAllYesNo()
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = 'YESNO' AND [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<CommonValueAndType>> GetCommonValueType(string type)
        {
            var query = "SELECT [Id],[Type],[SubType],[Value],[Text],[IsActive],[SortOrder] FROM [Config].[CommonValueAndType] WHERE [Type] = '"+ type + "' AND [IsDeleted] = 0";
            return await Get(query);
        }
    }
}
