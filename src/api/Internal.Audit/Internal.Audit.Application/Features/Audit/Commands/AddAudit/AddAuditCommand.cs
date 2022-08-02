using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Commands.AddAudit
{
    public class AddAuditCommand : IRequest<AddAuditResponseDTO>
    {
        public Guid AuditTypeId { get; set; }
        public Guid CountryId { get; set; }
        public string Year { get; set; }
        public string AuditName { get; set; }
        public Guid AuditPlanId{ get; set; }
        public string AuditId { get; set; }
        public DateTime AuditPeriodFrom { get; set; }
        public DateTime AuditPeriodTo { get; set; }
    }
}
