using Internal.Audit.Application.Contracts.Persistent.NotificationToAuditees;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.NotificationToAuditees;

public class NotificationToAuditeeQueryRepository : QueryRepositoryBase<CompositeNotificationToAuditee>, INotificationToAuditeeQueryRepository
{
	public NotificationToAuditeeQueryRepository(string _connectionString) : base(_connectionString)
	{
	}

	public async Task<(long, IEnumerable<CompositeNotificationToAuditee>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null)
	{
		string searchTermConverted = (object)searchTerm == null ? null : Convert.ToString(searchTerm);
		if (!string.IsNullOrWhiteSpace(searchTermConverted))
		{
			searchTermConverted = searchTermConverted.Replace("{", "").Replace("}", "");
		}
		var query = "EXEC [dbo].[NotificationToAuditeeListProcedure] @pageSize,@pageNumber,@searchTerm";
		var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTermConverted } };
		return await GetWithPagingInfo(query, parameters, false);
	}
}