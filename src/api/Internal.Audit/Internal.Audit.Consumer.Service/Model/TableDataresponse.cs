using System;

namespace Internal.Audit.Consumer.Service.Model
{
    public class TableDataresponse
    {
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public decimal Amount { get; set; }
        public Guid  Id { get; set; }
    }
}
