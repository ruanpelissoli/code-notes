using CodeNotes.Domain.Application;
using MediatR;

namespace CodeNotes.Application.Messaging;


public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
