using Internal.Audit.Application.Contracts.Persistent.Documents;
using Internal.Audit.Domain.Entities.common;
using Internal.Audit.Domain.Entities.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Documents;

public class DocumentQueryRepository : QueryRepositoryBase<Document>, IDocumentQueryRepository
{
    public DocumentQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<Document> GetByDocumentId(Guid id)
    {
        var query = @"SELECT *
                    FROM  [common].[Document]
                    inner join [Config].[DocumentSource]
                    on [common].[Document].[DocumentSourceId]=[Config].[DocumentSource].[Id]
                    where  [common].[Document].isdeleted=0 and [Config].[DocumentSource].[IsActive]=1 and [common].[Document].[Id]=@id";
        string splitters = "Id";
        var parameters = new Dictionary<string, object> { { "id", id } };
        var data = await Get<Document, DocumentSource, Document>(query, (document, documentsource) =>
        {
            Document doc;
            doc = document;
            doc.DocumentSource = documentsource;          

            return doc;
        }, parameters, splitters, false);
        return data.Distinct().FirstOrDefault();
    }
}
