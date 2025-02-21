using DemoShop.Application.Common.Interfaces;
using DemoShop.Domain.Core.Common.Abstractions;

namespace DemoShop.Application.Common;

public abstract class BaseCommand : ICommand<Result<long>>
{}