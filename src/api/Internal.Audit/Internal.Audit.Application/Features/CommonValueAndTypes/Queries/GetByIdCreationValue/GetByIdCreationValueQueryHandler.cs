using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetByIdCreationValue;

public class GetByIdCreationValueQueryHandler : IRequestHandler<GetByIdCreationQuery, GetByIdCreationValueDTO>
{
    private readonly ICommonValueAndTypeQueryRepository _commonValueAndTypesRepository;
    private readonly ICountryQueryRepository _countryRepository;
    private readonly IMapper _mapper;

    public GetByIdCreationValueQueryHandler(ICommonValueAndTypeQueryRepository commonValueAndTypesRepository, IMapper mapper, ICountryQueryRepository countryRepository)
    {
        _commonValueAndTypesRepository = commonValueAndTypesRepository ?? throw new ArgumentNullException(nameof(commonValueAndTypesRepository));
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<GetByIdCreationValueDTO> Handle(GetByIdCreationQuery request, CancellationToken cancellationToken)
    {
        var commonValue =await _commonValueAndTypesRepository.GetByIDCreationValue(request.value);
        var country = await _countryRepository.GetById(request.countryId);
        string auditType = request.auditType == 1 ? "BA" : "PNC";
        string code = commonValue.Text.Split('-')[0].Trim()+ auditType+country.Code+DateTime.Now.ToString("yyyyMMddHHmmss");
        return new GetByIdCreationValueDTO { Text = code };
    }
}
