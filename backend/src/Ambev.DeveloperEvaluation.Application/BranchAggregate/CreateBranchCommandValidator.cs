using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.BranchAggregate;

public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
{
    public CreateBranchCommandValidator()
    {
        RuleFor(sale => sale.Name).NotEmpty().NotNull().Length(3, 50);
        RuleFor(sale => sale.Location).NotEmpty().NotNull().Length(3, 100);
    }
}