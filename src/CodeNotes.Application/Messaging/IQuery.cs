using CodeNotes.Domain.Application;
using MediatR;

namespace CodeNotes.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
