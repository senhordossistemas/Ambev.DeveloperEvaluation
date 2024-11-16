using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CustomerAggregate;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(sale => sale.Name).NotEmpty().NotNull().Length(3, 50);
        RuleFor(sale => sale.ExternalId).NotEmpty().NotNull().Length(1, 50);
    }
}