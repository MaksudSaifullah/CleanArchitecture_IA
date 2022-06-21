using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserList.Commands.UpdateUser
{
    public class UpdateUserCommand: IRequest<UpdateUserResponseDTO>
    {
        //public UpdateUserCommandDTO User { get; set; }
        public Guid Id { get; set; }
        public bool IsAccountLocked { get; set; }

        //public UpdateUserCommand(Guid Id, bool isAccountLocked)
        //{
        //    this.Id = Id;
        //    IsAccountLocked = isAccountLocked;
        //}


    }
}
