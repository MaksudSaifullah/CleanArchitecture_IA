
using AutoMapper;
using Internal.Audit.Application.Contracts.Notifications;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Models;
using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.Security;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Internal.Audit.Application.Features.Users.Commands.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMailService _mailService;
    private readonly IConfiguration _configuration;
    private readonly IUserCommandRepository _userRepository;
    private readonly IMapper _mapper;

    public AddUserCommandHandler(IUserCommandRepository userRepository, IMapper mapper, 
        IUnitOfWork unitOfWork, IMailService mailService, IConfiguration configuration)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mailService = mailService;
        _configuration = configuration;
    }

    public async Task<AddUserResponseDTO> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        var newUser = await _userRepository.Add(user);
        var rowsAffected = await _unitOfWork.CommitAsync();

        if (rowsAffected > 0)
        {
            var mailVariables = new Dictionary<string, string> { { "NAME", "Valued Customer" } };
            await SendMail(user, mailVariables);
        }

        return new AddUserResponseDTO(newUser.Id, rowsAffected > 0, rowsAffected > 0 ? "User Added Successfully!" : "Error while adding user!");
    }

    private async Task<MailResponse> SendMail(User user, Dictionary<string, string> mailVariables)
    {
        return await _mailService.FormatSubject(_configuration["MailSettings:UserCreationMail:Subject"], "##", mailVariables)
                                        .FormatBody(_configuration["MailSettings:UserCreationMail:Body"], "##", mailVariables)
                                        .Setup(_configuration["MailSettings:DefaultSender"], new List<string> { user.UserName }, new List<string>(), true)
                                        .SendAsync();
    }
}
