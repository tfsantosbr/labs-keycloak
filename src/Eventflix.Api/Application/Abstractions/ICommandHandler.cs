namespace Eventflix.Api.Application.Abstractions;

public interface IHandler<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest command);
}