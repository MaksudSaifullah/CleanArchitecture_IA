﻿using Internal.Audit.Application.Contracts.Persistent.EmailConfigs;
using Internal.Audit.Domain.Entities.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.EmailConfig
{
    public class EmailConfigQueryRepository : QueryRepositoryBase<EmailConfiguration>, IEmailConfigQueryRepository
    {
        public EmailConfigQueryRepository(string _connectionString) : base(_connectionString)
        {

        }

        public async Task<(long, IEnumerable<EmailConfiguration>)> GetAll(int pageSize, int pageNumber)
        {
            var query = "EXEC [dbo].[GetEmailConfigListProcedure] @pageSize,@pageNumber";
            var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber } };
            return await GetWithPagingInfo(query, parameters, false);
        }

        public async Task<EmailConfiguration> GetById(Guid id)
        {
            var query = "SELECT [Id],[EmailTypeId],[CountryId],[TemplateSubject],[TemplateBody],[CreatedOn] FROM [Config].[EmailConfiguration] WHERE Id = @id AND[IsDeleted] = 0";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Single(query, parameters);
        }
    }
}
