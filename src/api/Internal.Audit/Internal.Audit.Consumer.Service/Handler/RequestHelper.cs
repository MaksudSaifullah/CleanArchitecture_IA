using Internal.Audit.Consumer.Service.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service.Handler
{
    public static class RequestHelper
    {
        public static RequestStatus GetRequestStatus(bool success, DateTime startDate, DateTime endDate, string error = "", bool compareOnly = false, int progression = 100, int statusId = -1)
        {
            var status = new RequestStatus();
            status.FromDate = startDate;           
           // status.EntityId = Int64.Parse(ConfigurationManager.AppSettings["entityId"]);
            status.ToDate = endDate;
            status.AmountConverted = 0;
            status.Amount = 0;
            status.BranchName = "";
            status.BranchCode = 0;
            status.BranchId = 0;
            
            return status;
        }

        public static void WriteInfoLog(string message)
        {
            Log.Information("{serviceName}: {infoMessage}",
                ConfigurationManager.AppSettings["log.entity"] + "-IAConsumer-Service", message);
        }

        public static void WriteErrorLog(string message)
        {
            Log.Information("{serviceName}: {errorMessage}",
                ConfigurationManager.AppSettings["log.entity"] + "-IAConsumer-Service", message);
        }
    }
}
