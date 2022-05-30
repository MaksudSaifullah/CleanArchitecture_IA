using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Countries.Commands.UpdateCountry;
public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, UpdateCountryResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICountryCommandRepository _countryRepository;
    private readonly IMapper _mapper;

    public UpdateCountryCommandHandler(ICountryCommandRepository countryRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateCountryResponseDTO> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.Get(request.Id);
        var mappedCountry = _mapper.Map(request,country);
        var updatedCountry =  await _countryRepository.Update(mappedCountry);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateCountryResponseDTO(updatedCountry.Id, rowsAffected > 0, rowsAffected > 0 ? "Country Updated Successfully!" : "Error while updating country!");
    }
}

