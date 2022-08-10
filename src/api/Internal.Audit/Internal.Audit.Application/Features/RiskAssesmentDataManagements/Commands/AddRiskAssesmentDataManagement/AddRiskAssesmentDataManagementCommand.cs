using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssesmentDataManagements.Commands.AddRiskAssesmentDataManagement;

public class AddRiskAssesmentDataManagementCommand:IRequest<AddRiskAssesmentDataManagementResponseDTO>
{
    public Guid DataRequestQueueServiceId { get; set; }
    public decimal ConversionRate { get; set; }
    public int TypeId { get; set; }
    public float Value { get; set; }
    public int Score { get; set; }
    public string Rating { get; set; }
    public bool IsDraft { get; set; }
    public int BranchId { get; set; }
}
