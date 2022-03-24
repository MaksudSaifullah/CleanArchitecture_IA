
using AutoMapper;
using Internal.Audit.Application.Features.Users.Queries.GetUserList;
using Internal.Audit.Domain.Entities;

namespace Internal.Audit.Application.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
    }
}
