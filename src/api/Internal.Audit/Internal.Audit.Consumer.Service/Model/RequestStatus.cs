using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service.Model
{
    public class RequestStatus
    {
        public Guid DataRequestQueueServiceId { get; set; }
        public int BranchCode { get; set; }
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountConverted { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CommonValueTableId { get; set; }
    }
}
