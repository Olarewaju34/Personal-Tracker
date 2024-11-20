using MediatR;
using PT.Domain.Abstraction;

namespace PT.Application.Abstraction.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}
public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{
}
public interface IBaseCommand
{
}


