﻿
using System;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetAuditConducted;
public record AuditConductedDTO
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string SubType { get; set; }
    public Int32 Value { get; set; }
    public string Text { get; set; }
}