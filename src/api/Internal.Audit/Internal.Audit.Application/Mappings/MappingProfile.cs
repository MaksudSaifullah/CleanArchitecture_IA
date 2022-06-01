
using AutoMapper;
using Internal.Audit.Application.Features.Countries.Commands.AddCountry;
using Internal.Audit.Application.Features.Countries.Commands.DeleteCountry;
using Internal.Audit.Application.Features.Countries.Commands.UpdateCountry;
using Internal.Audit.Application.Features.Countries.Queries.GetCountryById;
using Internal.Audit.Application.Features.Countries.Queries.GetCountryList;
using Internal.Audit.Application.Features.Designation.Commands.AddDesignation;
using Internal.Audit.Application.Features.Users.Commands.AddUser;
using Internal.Audit.Application.Features.Users.Commands.UpdateUser;
using Internal.Audit.Application.Features.Users.Queries.GetUserList;
using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.common;

namespace Internal.Audit.Application.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, AddUserCommand>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<Country, CountryDTO>().ReverseMap();
        CreateMap<Country, CountryByIdDTO>().ReverseMap();
        CreateMap<Country, AddCountryResponseDTO>().ReverseMap();
        CreateMap<Country, AddCountryCommand>().ReverseMap();
        CreateMap<Country, UpdateCountryResponseDTO>().ReverseMap();
        CreateMap<Country, UpdateCountryCommand>().ReverseMap();
        CreateMap<Country, DeleteCountryResponseDTO>().ReverseMap();
        CreateMap<Country, DeleteCountryCommand>().ReverseMap();
        CreateMap<Designation, AddDesignationResponseDTO>().ReverseMap();
        CreateMap<Designation, AddDesignationCommand>().ReverseMap();        
    }
}
