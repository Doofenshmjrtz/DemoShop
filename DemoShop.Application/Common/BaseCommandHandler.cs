using DemoShop.Application.Interfaces;
using DemoShop.Domain.Core.Common.Abstractions;

namespace DemoShop.Application.Common;

public abstract class BaseCommandHandler<TCommand, TResponse> : ICommandHandler<TCommand, TResponse> 
    where TCommand : BaseCommand<TResponse> where TResponse : Result<long>
{
    public abstract Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);
}