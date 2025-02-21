using MediatR;

namespace DemoShop.Application.Common.Interfaces;

public interface ICommand<out TResponse> : IRequest<TResponse>;