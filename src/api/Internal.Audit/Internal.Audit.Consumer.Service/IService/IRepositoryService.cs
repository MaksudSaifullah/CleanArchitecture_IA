using Internal.Audit.Consumer.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service.IService
{
    public interface IRepositoryService
    {
        //List<TableDataresponse> GetOverDueList(DateTime startDate, DateTime endDate,string type="overdue");
        List<TableDataresponse> GetData(DateTime startDate, DateTime endDate,string type,Guid DataRequestQueueServiceId, int CommonValueTableId);
       // List<TableDataresponse> GetLoanDisburtionList(DateTime startDate, DateTime endDate, string type = "loandisburse");
       // List<TableDataresponse> GetPrincipalList(DateTime startDate, DateTime endDate, string type = "principal");
    }
}
