﻿using Internal.Audit.Application.Features.Designation.Commands.AddDesignation;
using Internal.Audit.Application.Features.Designation.Commands.DeleteDesignation;
using Internal.Audit.Application.Features.Designation.Commands.UpdateDesignation;
using Internal.Audit.Application.Features.Designation.Queries.GetDesignationById;
using Internal.Audit.Application.Features.Designation.Queries.GetDesignationList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/designation")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DesignationController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost("paginated")]
        public async Task<ActionResult<GetDesignationListPagingDTO>> GetList(GetDesignationListQuery getDesignationListQuery)
        {           
            var designations = await _mediator.Send(getDesignationListQuery);
            return Ok(designations);

        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<GetDesignationByIdDTO>> GetById(Guid Id)
        {
            var query = new GetDesignationByIdQuery(Id);
            var designation = await _mediator.Send(query);
            return Ok(designation);

        }

        [HttpPost]
        public async Task<ActionResult<AddDesignationResponseDTO>> Add(AddDesignationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateDesignationResponseDTO>> Update(UpdateDesignationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteDesignationResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteDesignationCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
