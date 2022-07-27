using Asai.Ambs.Utility;
using Internal.Audit.Consumer.Service.IService;
using Internal.Audit.Consumer.Service.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service.Handler
{
    public class CompareRequestHandler : IRequestHandler
    {
        private readonly string _connectionString;
        private readonly IAPIService _apiService;
        private readonly IRepositoryService _repositoryService;
        private string token;

        public CompareRequestHandler()
        {
            _connectionString = DBUtility.DecryptConnectionString(ConfigurationManager
                .ConnectionStrings["Internal.Audit.Consumer.Service.ConnectionString"].ConnectionString);
            _apiService = new APIService();
            _repositoryService = new RepositoryService(_connectionString);
        }

        internal IRepositoryService RepositoryService => _repositoryService;

        public async Task<bool> ProcessRequest(DateTime startDate, DateTime endDate)
        {
            try
            {
               
            }
            catch (Exception e)
            {
                RequestHelper.WriteErrorLog("Ambs.Conso.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + e.Message);
                await _apiService.RequestCompletion(RequestHelper.GetRequestStatus(false, startDate, endDate, e.Message, true), token);
                return false;
            }
            //todo: call the process complete endpoint here // done
            var completed = await _apiService.RequestCompletion(RequestHelper.GetRequestStatus(true, startDate, endDate, "", true), token);
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
