using Internal.Audit.Domain.CompositeEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Branches.Commands.GetBranchList;

public class GetBranchListResponseDTO
{
    public IList<GetBranchListResponseDTORAW> Items { get; set; }
    [NotMapped]
    public long TotalCount { get; set; }
}
public class GetBranchListResponseDTORAW
{
    public int BranchCode { get; set; }
    public long BranchId { get; set; }
    public string? BranchName { get; set; }
    public Guid? Id { get; set; }
}
