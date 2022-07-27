using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service.Model
{
    public class RequestStatus
    {
        public long CountryId { get; set; }      
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Progression { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public bool CompareOnly { get; set; }
    }
}
