using DemoShop.Application.Interfaces;
using DemoShop.Domain.Core.Common.Abstractions;

namespace DemoShop.Application.Common;

public abstract class BaseCommand<TResponse> : ICommand<TResponse> 
    where TResponse : Result<long>
{}