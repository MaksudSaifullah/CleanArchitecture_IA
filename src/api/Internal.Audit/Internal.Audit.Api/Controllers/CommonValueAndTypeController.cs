﻿using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetAuditConducted;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetControlFrequency;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetDetestConclusion;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetEmailType;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetIssueStatus;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetLevelOfImpact;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetLevelOfLikelihood;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetLOProductivity;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetNatureOfControlActivity;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetRiskRating;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetRiskRatingName;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetSampledMonth;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetSampleSelectionMethod;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetYear;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetYesNo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/commonValueAndType")]
    [ApiController]
    public class CommonValueAndTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommonValueAndTypeController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpGet("auditconducted")]
        public async Task<ActionResult<IEnumerable<AuditConductedDTO>>> GetAllAuditConducted()
        {
            var query = new GetAuditConductedQuery();
            var auditconducted = await _mediator.Send(query);
            return Ok(auditconducted);
        }

        [HttpGet("controlfrequency")]
        public async Task<ActionResult<IEnumerable<ControlFrequencyDTO>>> GetAllControlFrequency()
        {
            var query = new GetControlFrequencyQuery();
            var controlfrequency = await _mediator.Send(query);
            return Ok(controlfrequency);
        }

        [HttpGet("detestconclusion")]
        public async Task<ActionResult<IEnumerable<DetestConclusionDTO>>> GetAllDetestConclusion()
        {
            var query = new GetDetestConclusionQuery();
            var detestconclusion = await _mediator.Send(query);
            return Ok(detestconclusion);
        }

        [HttpGet("emailtype")]
        public async Task<ActionResult<IEnumerable<EmailTypeDTO>>> GetAllEmailType()
        {
            var query = new GetEmailTypeQuery();
            var emailtype = await _mediator.Send(query);
            return Ok(emailtype);
        }

        [HttpGet("issuestatus")]
        public async Task<ActionResult<IEnumerable<IssueStatusDTO>>> GetAllIssueStatus()
        {
            var query = new GetIssueStatusQuery();
            var issuestatus = await _mediator.Send(query);
            return Ok(issuestatus);
        }

        [HttpGet("levelofimpact")]
        public async Task<ActionResult<IEnumerable<LevelOfImpactDTO>>> GetAllLevelOfImpact()
        {
            var query = new GetLevelOfImpactQuery();
            var levelofimpact = await _mediator.Send(query);
            return Ok(levelofimpact);
        }

        [HttpGet("leveloflikelihood")]
        public async Task<ActionResult<IEnumerable<LevelOfLikelihoodDTO>>> GetAllLevelOfLikelihood()
        {
            var query = new GetLevelOfLikelihoodQuery();
            var leveloflikelihood = await _mediator.Send(query);
            return Ok(leveloflikelihood);
        }

        [HttpGet("loproductivity")]
        public async Task<ActionResult<IEnumerable<LOProductivityDTO>>> GetAllLOProductivity()
        {
            var query = new GetLOProductivityQuery();
            var loproductivity = await _mediator.Send(query);
            return Ok(loproductivity);
        }

        [HttpGet("natureofcontrolactivity")]
        public async Task<ActionResult<IEnumerable<NatureOfControlActivityDTO>>> GetAllNatureOfControlActivity()
        {
            var query = new GetNatureOfControlActivityQuery();
            var natureofcontrolactivity = await _mediator.Send(query);
            return Ok(natureofcontrolactivity);
        }

        [HttpGet("riskrating")]
        public async Task<ActionResult<IEnumerable<RiskRatingDTO>>> GetAllRiskRating()
        {
            var query = new GetRiskRatingQuery();
            var riskrating = await _mediator.Send(query);
            return Ok(riskrating);
        }

        [HttpGet("riskratingname")]
        public async Task<ActionResult<IEnumerable<RiskRatingNameDTO>>> GetAllRiskRatingName()
        {
            var query = new GetRiskRatingNameQuery();
            var riskratingname = await _mediator.Send(query);
            return Ok(riskratingname);
        }

        [HttpGet("sampledmonth")]
        public async Task<ActionResult<IEnumerable<SampledMonthDTO>>> GetAllSampledMonth()
        {
            var query = new GetSampledMonthQuery();
            var sampledmonth = await _mediator.Send(query);
            return Ok(sampledmonth);
        }

        [HttpGet("sampleselectionmethod")]
        public async Task<ActionResult<IEnumerable<SampleSelectionMethodDTO>>> GetAllSampleSelectionMethod()
        {
            var query = new GetSampleSelectionMethodQuery();
            var sampleselectionmethod = await _mediator.Send(query);
            return Ok(sampleselectionmethod);
        }

        [HttpGet("year")]
        public async Task<ActionResult<IEnumerable<YearDTO>>> GetAllYear()
        {
            var query = new GetYearQuery();
            var year = await _mediator.Send(query);
            return Ok(year);
        }

        [HttpGet("yesno")]
        public async Task<ActionResult<IEnumerable<YesNoDTO>>> GetAllYesNo()
        {
            var query = new GetYesNoQuery();
            var yesno = await _mediator.Send(query);
            return Ok(yesno);
        }
    }
}
