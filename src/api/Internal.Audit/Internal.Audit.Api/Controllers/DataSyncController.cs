using Internal.Audit.Application.Features.AmbsDataSyncs.Command.AddAmbsDataSyncCommand;
using Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetAmbsDataSyncDataByCountryAndDateInfo;
using Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetRiskAssesmentData;
using Internal.Audit.Application.Features.RiskAssesmentConsolidateDatas.Commands.AddConsolidateData;
using Internal.Audit.Application.Features.RiskAssesmentConsolidateDatas.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers;

[Route("api/v{version:apiVersion}/DataSync")]
[ApiController]
public class DataSyncController : ControllerBase
{
    private readonly IMediator _mediator;
    public DataSyncController(IMediator madiator)
    {
        _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
    }


    [HttpPost]
    public async Task<ActionResult<AddAmbsDataSyncCommandDTO>> GetList(AddAmbsDataSyncCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);


    }
    [HttpPost("getSyncData")]
    public async Task<ActionResult<GetAmbsDataSyncDataByCountryAndDateInfoDTO>> GetList(GetAmbsDataSyncDataByCountryAndDateInfoQuery command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);


    }
    [HttpPost("getSyncDataRiskAssesment")]
    public async Task<ActionResult<GetRiskAssesmentDataQueryDTO>> GetSyncDataRiskAssesment(GetRiskAssesmentDataQuery command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);


    }
    [HttpPost("getSyncDataRiskAssesmentAvg")]
    public async Task<ActionResult<RiskConsolidateDataGetQueryResponseDTO>> GetSyncDataRiskAssesmentAvg(RiskConsolidateDataGetQuery command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);


    }
    [HttpPost("PostAvgData")]
    public async Task<ActionResult<AddConsolidateDataResponseDTO>> PostAvgData(AddConsolidateDataCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);


    }
}
