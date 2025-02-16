using DemoShop.Domain.Core.Common.Abstractions;
using MediatR;

namespace DemoShop.Application.Interfaces;

public interface ICommand : IRequest<Result> {}

public interface ICommand<TResponse> : IRequest<Result<TResponse>> {}