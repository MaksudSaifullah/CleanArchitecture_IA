﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Designation.Queries.GetDesignationById;
public record GetDesignationByIdQuery(Guid Id) : IRequest<GetDesignationByIdDTO>;