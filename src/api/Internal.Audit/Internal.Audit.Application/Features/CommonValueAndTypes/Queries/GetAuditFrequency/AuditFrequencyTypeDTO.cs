using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetAuditFrequency;

public record AuditFrequencyTypeDTO
{
public Guid Id { get; set; }
public string Type { get; set; }
public string SubType { get; set; }
public int Value { get; set; }
public string Text { get; set; }
}