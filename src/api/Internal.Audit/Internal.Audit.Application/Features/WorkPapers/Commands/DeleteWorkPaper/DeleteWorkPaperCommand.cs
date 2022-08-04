using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WorkPapers.Commands.DeleteWorkPaper;

public class DeleteWorkPaperCommand : IRequest<DeleteWorkPaperResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteWorkPaperCommand(Guid id)
    {
        Id = id;
    }
}
