using Internal.Audit.Consumer.Service.Handler;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service
{
    public partial class ConsumerService : ServiceBase
    {
        public ConsumerService()
        {
            InitializeComponent();
           

        }

        protected override void OnStart(string[] args)
        {
            Log.Information("{serviceName} started", ConfigurationManager.AppSettings["log.entity"] + "-IAConsumer-Service");
            Consume();
        }

        protected override void OnStop()
        {
            Log.Information("{serviceName} stopped", ConfigurationManager.AppSettings["log.entity"] + "-IAConsumer-Service");

        }

        public  void Consume()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(ConfigurationManager.AppSettings["brokerAddress"])
                };
                var con = factory.CreateConnection();
                var channel = con.CreateModel();
                channel.QueueDeclare(ConfigurationManager.AppSettings["brokerQueue"], durable: true, exclusive: false, autoDelete: false, arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Queue inititated successfully.");
                consumer.Received += (sender, e) =>
                {
                    try
                    {
                        //RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Request received.");

                        //channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
                        //return;
                        RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Request received.");
                        if (e.Redelivered)
                        {
                            RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Redelivered Request received.");
                            return;
                        }
                        var body = e.Body.ToArray();
                        RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Body parsed.");
                        var message = Encoding.UTF8.GetString(body);
                        RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "String parsed.");
                        var messaJObject = JObject.Parse(message);
                        RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Json parsed.");
                        //todo>> do your task here
                        if (messaJObject["FromDate"] == null || messaJObject["ToDate"] == null)
                        {
                            RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Date is null.");
                            channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
                            return;
                        }
                        var startDate = messaJObject["FromDate"] != null ? Convert.ToDateTime(messaJObject["FromDate"].ToString()) : DateTime.MinValue;
                        RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Start date: " + startDate);
                        var endDate = messaJObject["ToDate"] != null ? Convert.ToDateTime(messaJObject["ToDate"].ToString()) : DateTime.MinValue;
                        RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "End date: " + endDate);
                        var _requestHandler = new RequestHandlerFactory().GetRequestHandler(false);


                        //RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "factory product received.");
                        //RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "received request: ." + messaJObject);
                        //RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "process is about to start ");
                        var isProcessed = _requestHandler.ProcessRequest(startDate, endDate).GetAwaiter().GetResult();
                        RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "process ended.");
                        if (!isProcessed)
                            RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "Requested Operation Failed.");
                        //todo>> do your task here
                        RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "going for message acknowledgment.");
                        channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
                        RequestHelper.WriteInfoLog("Internal.Audit.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "message acknowledged.");
                    }
                    catch (Exception ex)
                    {
                        RequestHelper.WriteErrorLog("Ambs.Conso.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + "error on arrow: " + ex.Message);
                    }

                };
               channel.BasicConsume(ConfigurationManager.AppSettings["brokerQueue"], false, consumer);
            }
            catch (Exception e)
            {
                RequestHelper.WriteErrorLog("Ambs.Conso.Consumer.Service Method: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "::" + e.Message);
            }
        }
    }
}
