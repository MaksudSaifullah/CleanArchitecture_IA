﻿using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetCommonValueTypeGeneric
{
    public class GetCommonValueTypeQueryHandler : IRequestHandler<GetCommonValueTypeQuery, List<GetCommonValueTypeGenericDTO>>
    {
        private readonly ICommonValueAndTypeQueryRepository _commonValueAndTypesRepository;
        private readonly IMapper _mapper;

        public GetCommonValueTypeQueryHandler(ICommonValueAndTypeQueryRepository commonValueAndTypesRepository, IMapper mapper)
        {
            _commonValueAndTypesRepository = commonValueAndTypesRepository ?? throw new ArgumentNullException(nameof(commonValueAndTypesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetCommonValueTypeGenericDTO>> Handle(GetCommonValueTypeQuery request, CancellationToken cancellationToken)
        {
            var commonValueAndTypes = await _commonValueAndTypesRepository.GetCommonValueType(request.type);
            return _mapper.Map<List<GetCommonValueTypeGenericDTO>>(commonValueAndTypes);

        }

    }
}
