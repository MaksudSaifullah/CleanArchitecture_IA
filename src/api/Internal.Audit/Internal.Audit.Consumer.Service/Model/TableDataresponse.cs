using System;
using System.Collections.Generic;

namespace Internal.Audit.Consumer.Service.Model
{
    public class TableDataresponse
    {
        public long BranchId { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public decimal Amount { get; set; }
        public Guid DataRequestQueueServiceId { get; set; }
        public decimal? AmountConverted { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CommonValueTableId { get; set; }
    }

    public class RequestAPI
    {
        public List<TableDataresponse> dataGet { get; set; }
    }

    

}
