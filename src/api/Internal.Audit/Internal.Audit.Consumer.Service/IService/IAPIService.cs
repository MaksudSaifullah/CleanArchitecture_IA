using Internal.Audit.Consumer.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service.IService
{
    public interface IAPIService
    {
        Task<bool> PostData(List<TableDataresponse> data, string token);
        //Task<bool> PostLoanDisburtionData(List<TableDataresponse> data, string token, bool compareOnly = false);
        Task<bool> RequestCompletion(RequestStatus data, string token);       
        Task<string> GetToken();       
     
    }
}
