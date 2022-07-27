using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailConfigById
{
    public record GetEmailConfigByIdResponseDTO
    {
        public Guid Id { get; set; }
        public Guid EmailTypeId { get; set; }
        public Guid CountryId { get; set; }
        public string TemplateSubject { get; set; }
        public string TemplateBody { get; set; }
        public DateTime CreatedOn { get; set; }

        //public virtual ICollection<EmailType> EmailTypes { get; set; } = null!;

        //public virtual ICollection<Country> Countries { get; set; } = null!;
    }
}
