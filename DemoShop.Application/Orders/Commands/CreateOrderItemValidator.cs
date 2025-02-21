using FluentValidation;

namespace DemoShop.Application.Orders.Commands;

public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemCommand>
{
    public CreateOrderItemValidator() => 
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();
}