using FluentValidation;

namespace DemoShop.Application.Orders.Queries;

public class GetOrderItemByIdValidator : AbstractValidator<GetOrderItemByIdQuery>
{
    public GetOrderItemByIdValidator() => 
        RuleFor(x => x.Id)
        .NotNull()
        .NotEmpty();
}