using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.Config;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Commands.AddEmailConfig;
public class AddEmailConfigCommand : IRequest<AddEmailConfigResponseDTO>
{
    public Guid EmailTypeId { get; set; }
    public Guid CountryId { get; set; }
    public string TemplateSubject { get; set; }
    public string TemplateBody { get; set; }

}
