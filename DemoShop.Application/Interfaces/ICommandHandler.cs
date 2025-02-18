using MediatR;

namespace DemoShop.Application.Interfaces;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{}