using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.User.Dto
{
    public record CreateNewUserDto(string FirstName, string LastName, string PhoneNumber, string UserName, string Password);

}
