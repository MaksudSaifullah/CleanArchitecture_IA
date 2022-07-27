using Asai.Ambs.Utility;
using Internal.Audit.Consumer.Service.IService;
using Internal.Audit.Consumer.Service.Model;
using Internal.Audit.Consumer.Service.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service.Handler
{
    public class RequestHandler : IRequestHandler
    {
        private readonly string _connectionString;
        private readonly IAPIService _apiService;
        private readonly IRepositoryService _repositoryService;
        private string token="";

        public RequestHandler()
        {
            _connectionString = DBUtility.DecryptConnectionString(ConfigurationManager
                .ConnectionStrings["Internal.Audit.Consumer.Service.ConnectionString"].ConnectionString);
            _apiService = new APIService();
            _repositoryService = new RepositoryService(_connectionString);
        }

        //public IRepositoryService RepositoryService => _repositoryService;

        public async Task<bool> ProcessRequest(DateTime startDate, DateTime endDate)
        {
            try
            {
                //todo: add the clusteredEntityCheck and get the branchId into a var if exist
               
                await _apiService.RequestCompletion(RequestHelper.GetRequestStatus(false, startDate, endDate, "process initiated", false, 1, 2), token);
                //fetch branch list
                var dataListOverdue = _repositoryService.GetData(startDate, endDate, "Overdue");
                if (!dataListOverdue.Any())
                {
                    await _apiService.RequestCompletion(RequestHelper.GetRequestStatus(false, startDate, endDate, "empty  list"), token);
                    return false;
                }
                var dataListCollection = _repositoryService.GetData(startDate, endDate, "Collection");
                if (!dataListCollection.Any())
                {
                    await _apiService.RequestCompletion(RequestHelper.GetRequestStatus(false, startDate, endDate, "empty  list"), token);
                    return false;
                }

                var dataListDisburse = _repositoryService.GetData(startDate, endDate, "Disburse");
                if (!dataListDisburse.Any())
                {
                    await _apiService.RequestCompletion(RequestHelper.GetRequestStatus(false, startDate, endDate, "empty  list"), token);
                    return false;
                }
                return true;
                var isDataPostedOverDue = await _apiService.PostData(dataListOverdue, token);
                var isDataPostedCollection = await _apiService.PostData(dataListCollection, token);
                var isDataPostedDisburse = await _apiService.PostData(dataListDisburse, token);
                if(!isDataPostedOverDue || !isDataPostedCollection || !isDataPostedDisburse)
                {
                    return false;  
                }

            }
            catch (Exception e)
            {
                RequestHelper.WriteErrorLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + e.Message);
                await _apiService.RequestCompletion(RequestHelper.GetRequestStatus(false, startDate, endDate, e.Message), token);
                return false;
            }
            //todo: call the process complete endpoint here // done
            var completed = await _apiService.RequestCompletion(RequestHelper.GetRequestStatus(true, startDate, endDate), token);
            if (completed)
                RequestHelper.WriteInfoLog("Ambs.Conso.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "All Chunks processed successfully!");
            else
            {
                RequestHelper.WriteInfoLog("Ambs.Conso.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "All processed except completion request!");
            }
            return true;
        }
    }
}
