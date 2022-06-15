using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserList.Commands.UpdateUser;
public class UpdateEmployeeCommandDTO
{
	public Guid EmployeeId { get; set; }
	public Guid UserId { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }


}
