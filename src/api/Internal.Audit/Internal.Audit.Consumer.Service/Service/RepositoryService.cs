using Internal.Audit.Consumer.Service.Handler;
using Internal.Audit.Consumer.Service.IService;
using Internal.Audit.Consumer.Service.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service.Service
{
    public class RepositoryService : IRepositoryService
    {
        private readonly string _connectionString;
        public RepositoryService(string connectionString)
        {
            _connectionString = connectionString;
        }
        private void SetArithAbortCommand(SqlConnection connection)
        {
            using (SqlCommand comm = new SqlCommand("SET ARITHABORT ON", connection))
            {
                comm.ExecuteNonQuery();
            }
        }
        public List<TableDataresponse> GetData(DateTime startDate, DateTime endDate, string type = "loandisburse")
        {
            RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Fetching aging data");
            var dynamicList = new List<TableDataresponse>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    //var initialAgingRow = int.Parse(ConfigurationManager.AppSettings["initialAgingRow"]);
                    connection.Open();
                    SetArithAbortCommand(connection);
                    var sqlCmd = new SqlCommand(@"[dbo].[AMBSDataProcedure]", connection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = 5000;
                    sqlCmd.Parameters.AddWithValue("StartDate", startDate.ToString("yyyy-MM-dd") + " 00:00:00");
                    sqlCmd.Parameters.AddWithValue("EndDate", endDate.ToString("yyyy-MM-dd") + " 00:00:00");
                    sqlCmd.Parameters.AddWithValue("ReportType", type);


                    using (var sqlReader = sqlCmd.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            dynamicList.Add(new TableDataresponse
                            {
                                Id = Guid.NewGuid(),
                                Amount = decimal.Parse(sqlReader["Amount"].ToString()),
                                BranchId = long.Parse(sqlReader["Amount"].ToString()),
                                BranchName =sqlReader["BranchName"].ToString(),
                                
                            });
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                RequestHelper.WriteErrorLog("Ambs.Conso.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + e.Message);
            }
            RequestHelper.WriteInfoLog("Ambs.Conso.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Aging Data fetch successful");
            return dynamicList;
        }


    }
}
