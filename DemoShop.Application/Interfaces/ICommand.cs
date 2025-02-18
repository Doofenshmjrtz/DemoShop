using MediatR;

namespace DemoShop.Application.Interfaces;

public interface ICommand<out TResponse> : IRequest<TResponse> {}