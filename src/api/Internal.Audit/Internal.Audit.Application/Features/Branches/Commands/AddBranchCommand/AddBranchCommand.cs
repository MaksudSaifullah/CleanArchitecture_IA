using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Branches.Commands.AddBranchCommand;

public class AddBranchCommand:IRequest<AddBranchCommandDTO>
{
    public Guid CountryId { get; set; }
    public int BranchCode { get; set; }
    public long BranchId { get; set; } 
    public string? BranchName { get; set; }
}
