using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssesmentDataManagementLogs.Commands.AddRiskAssesmentDataManagementLog;

public class AddRiskAssesmentDataManagementLogCommand:IRequest<AddRiskAssesmentDataManagementLogResponseDTO>
{
    public Guid DataRequestQueueServiceId { get; set; }
    public decimal ConversionRate { get; set; }
    public int TypeId { get; set; }

    public List<RiskAssesmentDataManagementCommand> RiskAssesmentDataManagement { get; set; } 
}
public class RiskAssesmentDataManagementCommand
{
    public float Value { get; set; }
    public int Score { get; set; }
    public string Rating { get; set; }
    public bool IsDraft { get; set; }
    public int BranchId { get; set; }

}
