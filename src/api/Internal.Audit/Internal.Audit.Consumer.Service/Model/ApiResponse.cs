using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service.Model
{
    public class ApiResponse
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsSuccess { get; set; }
        public string Msg { get; set; }
    }
}
