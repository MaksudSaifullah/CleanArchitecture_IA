
using AutoMapper;
using Internal.Audit.Application.Features.Countries.Queries.GetCountryList;
using Internal.Audit.Application.Features.Users.Commands.AddUser;
using Internal.Audit.Application.Features.Users.Commands.UpdateUser;
using Internal.Audit.Application.Features.Users.Queries.GetUserList;
using Internal.Audit.Domain.Entities;

namespace Internal.Audit.Application.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, AddUserCommand>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<Country, CountryDTO>().ReverseMap();
    }
}
