﻿using MediatR;
using PT.Application.Abstraction.Messaging;
using PT.Domain.Abstraction;
using PT.Domain.Entities.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Command.User
{
    public class CrreateNewUserCommandHandler(IUser) : ICommandHandler<CreateNewUserDto,Result>
    {
    }
}
