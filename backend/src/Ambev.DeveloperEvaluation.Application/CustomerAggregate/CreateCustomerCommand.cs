using Ambev.DeveloperEvaluation.Application.BranchAggregate;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CustomerAggregate;

public sealed record CreateCustomerCommand(
    string Name,
    string ExternalId) : IRequest<CreateCustomerResult>
{

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCustomerCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

}