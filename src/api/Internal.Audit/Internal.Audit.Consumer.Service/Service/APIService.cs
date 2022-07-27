using Internal.Audit.Consumer.Service.Handler;
using Internal.Audit.Consumer.Service.IService;
using Internal.Audit.Consumer.Service.Model;
using Internal.Audit.Consumer.Service.ServiceConstants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service.Service
{
    public class APIService : IAPIService
    {
        public APIService()
        {
        }
        //todo: post data and clean request and fetch token
   
        public async Task<bool> RequestCompletion(RequestStatus data, string token)
        {
            try
            {
                return true;
                RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "requesting process completion");
                var url = ConfigurationManager.AppSettings["baseApi"] + ConfigurationManager.AppSettings["completeRequestEndpoint"];
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromMinutes(10);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = JsonConvert.SerializeObject(data);
                var encodedContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync(url, encodedContent);
                string responseBody = await res.Content.ReadAsStringAsync();
                if (!res.IsSuccessStatusCode)
                {
                    RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Error while requesting process completion.");
                    return false;
                }

                if (responseBody == "0")
                {
                    RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Error on API side");
                    return false;
                }
                RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "complete request posted.");
                return true;
            }
            catch (Exception e)
            {
                RequestHelper.WriteErrorLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + e.Message);
                return false;
            }

        }


        public async Task<string> GetToken()
        {
            var token = string.Empty;
            try
            {
                RequestHelper.WriteInfoLog("Ambs.Conso.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "requesting fetch token");
                var url = ConfigurationManager.AppSettings["baseApi"] + ConfigurationManager.AppSettings["loginEndpoint"];
                //var formVariables = new List<KeyValuePair<string, string>>();
                ////formVariables.Add(new KeyValuePair<string, string>("UserId", Constants.USER_ID));
                ////formVariables.Add(new KeyValuePair<string, string>("Password", Constants.PASSWORD));
                //var formContent = new FormUrlEncodedContent(formVariables);
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(10);
                    var data = new
                    {
                        UserId = Constants.USER_ID,
                        Password = Constants.PASSWORD
                    };
                    var content = JsonConvert.SerializeObject(data);
                    var encodedContent = new StringContent(content, Encoding.UTF8, "application/json");
                    HttpResponseMessage res = await client.PostAsync(url, encodedContent);
                    var responseContent = await res.Content.ReadAsStringAsync();
                    var resObject = JsonConvert.DeserializeObject<ApiResponse>(responseContent);
                    token = resObject.Token;
                    if (!string.IsNullOrEmpty(token))
                        RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "token fetch successful");
                    return token;
                }
            }
            catch (Exception e)
            {
                RequestHelper.WriteErrorLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + e.Message);
                throw;
            }

        }

        public async Task<bool> PostData(List<TableDataresponse> data, string token, bool compareOnly = false)
        {
            try
            {
                RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "posting journal data for branch Id: " + data.FirstOrDefault()?.BranchId);
                var url = ConfigurationManager.AppSettings["baseApi"];
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromMinutes(10);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = JsonConvert.SerializeObject(data);
                var encodedContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync(url, encodedContent);
                string responseBody = await res.Content.ReadAsStringAsync();
                if (!res.IsSuccessStatusCode)
                {
                    RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Error while posting data.");
                    return false;
                }

                if (responseBody == "false")
                {
                    RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Error: " + "Error on API side");
                    return false;
                }
                RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "journal posted successfully.");
                return true;
            }
            catch (Exception e)
            {
                RequestHelper.WriteErrorLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + e.Message);
                return false;
            }
        }

        public async Task<bool> PostLoanDisburtionData(List<TableDataresponse> data, string token, bool compareOnly = false)
        {
            try
            {
                RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "posting journal data for branch Id: " + data.FirstOrDefault()?.BranchId);
                var url = ConfigurationManager.AppSettings["baseApi"];
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromMinutes(10);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = JsonConvert.SerializeObject(data);
                var encodedContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync(url, encodedContent);
                string responseBody = await res.Content.ReadAsStringAsync();
                if (!res.IsSuccessStatusCode)
                {
                    RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Error while posting data.");
                    return false;
                }

                if (responseBody == "false")
                {
                    RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Error: " + "Error on API side");
                    return false;
                }
                RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "journal posted successfully.");
                return true;
            }
            catch (Exception e)
            {
                RequestHelper.WriteErrorLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + e.Message);
                return false;
            }
        }
    }
}
