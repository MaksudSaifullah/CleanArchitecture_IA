﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetEmailType;
public record GetEmailTypeQuery(Guid Id) : IRequest<EmailTypeDTO>;


