using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Designations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Designation.Queries.GetDesignationById;
public class GetDesignationByIdQueryHandler : IRequestHandler<GetDesignationByIdQuery, GetDesignationByIdDTO>
{
    private readonly IDesignationQueryRepository _designationRepository;
    private readonly IMapper _mapper;

    public GetDesignationByIdQueryHandler(IDesignationQueryRepository designationRepository, IMapper mapper)
    {
        _designationRepository = designationRepository ?? throw new ArgumentNullException(nameof(designationRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetDesignationByIdDTO> Handle(GetDesignationByIdQuery request, CancellationToken cancellationToken)
    {
        var designation = await _designationRepository.GetById(request.Id);
        return _mapper.Map<GetDesignationByIdDTO>(designation);
    }
}

