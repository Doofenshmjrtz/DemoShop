using FluentValidation;

namespace DemoShop.Application.Orders.Commands.CreateOrderItem;

public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemCommand>
{
    public CreateOrderItemValidator() => 
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();
}