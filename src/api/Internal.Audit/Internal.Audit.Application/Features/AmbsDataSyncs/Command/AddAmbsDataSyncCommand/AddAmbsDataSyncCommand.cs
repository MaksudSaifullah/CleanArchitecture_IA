using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AmbsDataSyncs.Command.AddAmbsDataSyncCommand;

public class AddAmbsDataSyncCommand : IRequest<AddAmbsDataSyncCommandDTO>
{
    public IList<AddAmbsDataSyncCommandRequest> DataGet { get; set; }
}
public class AddAmbsDataSyncCommandRequest
{
    public Guid DataRequestQueueServiceId { get; set; }
    public int BranchCode { get; set; }
    public long BranchId { get; set; }    
    public string? BranchName { get; set; }
    public decimal Amount { get; set; }
    public decimal? AmountConverted { get; set; }   
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }  
    public int CommonValueTableId { get; set; }
}
