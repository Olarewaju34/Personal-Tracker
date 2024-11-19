using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.User.Dto
{
    public record UpdateUserDto(string UserName, string Password);

}
