using PT.Application.Abstraction.Messaging;
using PT.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Command.User.Auth
{
    public record LoginCommad(string Email, string Password): ICommand<Result>
}
