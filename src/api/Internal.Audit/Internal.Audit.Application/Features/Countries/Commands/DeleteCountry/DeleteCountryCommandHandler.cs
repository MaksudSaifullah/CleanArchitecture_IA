using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using MediatR;

namespace Internal.Audit.Application.Features.Countries.Commands.DeleteCountry;

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, DeleteCountryResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICountryCommandRepository _countryRepository;
    private readonly IMapper _mapper;

    public DeleteCountryCommandHandler(ICountryCommandRepository countryRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<DeleteCountryResponseDTO> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.Get(request.Id);
        country.IsDeleted = true;
        var mappedCountry = _mapper.Map(request, country);
        await _countryRepository.Update(mappedCountry);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteCountryResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Country Deleted Successfully!" : "Error while deleting country!");
    }
}