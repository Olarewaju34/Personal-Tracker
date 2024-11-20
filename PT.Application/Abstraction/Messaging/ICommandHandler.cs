﻿using MediatR;
using PT.Domain.Abstraction;

namespace PT.Application.Abstraction.Messaging
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand
    {
    }
    public interface ICommandHandler<TCommand,TResponse> : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>
    {
    }
}



