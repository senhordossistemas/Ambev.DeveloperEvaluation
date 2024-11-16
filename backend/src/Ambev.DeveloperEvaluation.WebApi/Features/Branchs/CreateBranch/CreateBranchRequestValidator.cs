using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;

public class CreateBranchRequestValidator : AbstractValidator<CreateBranchRequest>
{
    public CreateBranchRequestValidator()
    {
        RuleFor(sale => sale.Name).NotEmpty().NotNull().Length(3, 50);
        RuleFor(sale => sale.Location).NotEmpty().NotNull().Length(3, 50);
    }
}