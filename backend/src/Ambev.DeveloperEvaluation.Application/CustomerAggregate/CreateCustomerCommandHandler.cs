using Ambev.DeveloperEvaluation.Domain.Models.BranchAggregate.Repositories;
using Ambev.DeveloperEvaluation.Domain.Models.CustomerAggregate.Entities;
using Ambev.DeveloperEvaluation.Domain.Models.CustomerAggregate.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CustomerAggregate;

public class CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
{
    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var branch = mapper.Map<Customer>(command);

        var createdcustomer = await customerRepository.CreateAsync(branch, cancellationToken);
        var result = mapper.Map<CreateCustomerResult>(createdcustomer);
        return result;
    }
}