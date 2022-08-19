using Internal.Audit.Application.Contracts.Persistent.UploadDocuments;
using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities.common;
using Internal.Audit.Domain.Entities.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UploadDocuments;

public class UploadDocumentQueryRepository : QueryRepositoryBase<UploadDocument>, IUploadDocumentQueryRepository
{
    public UploadDocumentQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<IEnumerable<UploadDocument>> GetAllAsyncByRoleId(Guid RoleId,int pageSize, int pageNumber)
    {
        //var query = @"declare @totalcount  bigint
        //            declare @pageSize int="+ pageSize + @" 
        //            declare @pageNumber int=" + pageNumber + @" 
        //            select @totalcount=count(*) FROM [Config].[UploadDocument] x
        //            where x.IsDeleted=0
        //            and  CAST(GETDATE()  as date) between CAST(ActiveFrom as  date) and CAST(ActiveTo as date)

        //            select *,@totalcount TC FROM [Config].[UploadDocument] x
        //            inner join [Config].[UploadedDocumentsNotify]  y
        //            on x.id=y.UploadDocumentId
        //            inner join [common].Document z
        //            on x.DocumentId=z.Id
        //            --where  y.RoleId =''
        //            where x.IsDeleted=0
        //            and  CAST(GETDATE()  as date) between CAST(ActiveFrom as  date) and CAST(ActiveTo as date)
        //            order by x.CreatedOn desc
        //            --OFFSET case when  @pageSize=-1 then 0 else ((@pageNumber-1) * @pageSize) end ROWS
        //           -- FETCH NEXT case when @pageSize=-1 THEN case when @totalcount=0 then 1 else @totalcount end  else @pageSize end  ROWS ONLY;
        //            ";

        var query = @"declare @totalcount  bigint
                    declare @pageSize int=" + pageSize + @" 
                    declare @pageNumber int=" + pageNumber + @" 
                    select @totalcount=count(*) FROM [Config].[UploadDocument] x
                    where x.IsDeleted=0
                    and  CAST(GETDATE()  as date) between CAST(ActiveFrom as  date) and CAST(ActiveTo as date)

                    select x.*,z.*,@totalcount TC FROM [Config].[UploadDocument] x
                    --inner join [Config].[UploadedDocumentsNotify]  y
                    --on x.id=y.UploadDocumentId
                    inner join [common].Document z
                    on x.DocumentId=z.Id
                    --left join [Config].[UploadedDocumentsNotify]  y
                    --on x.id=y.UploadDocumentId
                    --where  y.RoleId =''
                    where x.IsDeleted=0
                    and  CAST(GETDATE()  as date) between CAST(ActiveFrom as  date) and CAST(ActiveTo as date)
                    order by x.CreatedOn  desc
                    OFFSET case when  @pageSize=-1 then 0 else ((@pageNumber-1) * @pageSize) end ROWS
                    FETCH NEXT case when @pageSize=-1 THEN case when @totalcount=0 then 1 else @totalcount end  else @pageSize end  ROWS ONLY;
                    ";
        string splitters = "Id,TC";
        var parameters = new Dictionary<string, object> { };
        var documentDictionary = new Dictionary<Guid, UploadDocument>();
        var notifyDictionary = new Dictionary<Guid, UploadedDocumentsNotify>();
        var data = await Get<UploadDocument, Document, EfTotalCount, UploadDocument >(query, (uploaddocument, document, totalcount) =>
            {


                UploadDocument u;
                if (!documentDictionary.ContainsKey(uploaddocument.Id))
                {
                    documentDictionary.Add(uploaddocument.Id, uploaddocument);
                    u = uploaddocument;
                    u.UploadedDocumentsNotify = new List<UploadedDocumentsNotify>();

                }
                else
                {
                    u = documentDictionary[uploaddocument.Id];
                }

                //if (!notifyDictionary.ContainsKey(notifylist.Id))
                //{
                //    notifyDictionary.Add(notifylist.Id, notifylist);
                //    u.UploadedDocumentsNotify.Add(notifylist);
                //}
                u.TotalCount = totalcount;
                u.Document = document;
                return u;
            }, parameters, splitters, false);
        return data.Distinct();
    }
}
