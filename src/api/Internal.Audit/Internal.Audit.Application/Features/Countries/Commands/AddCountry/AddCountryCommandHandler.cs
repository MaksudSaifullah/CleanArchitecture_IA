using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Countries.Commands.AddCountry;

public class AddCountryCommandHandler : IRequestHandler<AddCountryCommand, AddCountryResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;        
    private readonly ICountryCommandRepository _countryRepository;
    private readonly IMapper _mapper;

    public AddCountryCommandHandler(ICountryCommandRepository countryRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));        
    }
    public async Task<AddCountryResponseDTO> Handle(AddCountryCommand request, CancellationToken cancellationToken)
    {
        var country = _mapper.Map<Country>(request);
        var newCountry = await _countryRepository.Add(country);
        var rowsAffected = await _unitOfWork.CommitAsync();

        //if (rowsAffected > 0)
        //{
        //    var mailVariables = new Dictionary<string, string> { { "NAME", "Valued Customer" } };
        //    await SendMail(user, mailVariables);
        //}

        return new AddCountryResponseDTO(newCountry.Id, rowsAffected > 0, rowsAffected > 0 ? "Country Added Successfully!" : "Error while creating country!");
    }

}

