using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Branches.Commands.GetBranchList;

public class GetBranchListResponseDTO
{
    public int BranchCode { get; set; }
    public long BranchId { get; set; }    
    public string? BranchName { get; set; }
    public Guid? Id { get; set; }
}
