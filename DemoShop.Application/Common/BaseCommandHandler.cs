using DemoShop.Application.Common.Interfaces;
using DemoShop.Domain.Core.Common.Abstractions;

namespace DemoShop.Application.Common;

public abstract class BaseCommandHandler<TCommand> : ICommandHandler<TCommand, Result<long>> 
    where TCommand : BaseCommand
{
    public abstract Task<Result<long>> Handle(TCommand request, CancellationToken cancellationToken);
}