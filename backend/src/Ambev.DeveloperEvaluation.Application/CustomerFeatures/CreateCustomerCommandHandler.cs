using Ambev.DeveloperEvaluation.Domain.Models.CustomerAggregate.Entities;
using Ambev.DeveloperEvaluation.Domain.Models.CustomerAggregate.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CustomerFeatures;

public class CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
{
    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var customer = mapper.Map<Customer>(command);

        var createdCustomer = await customerRepository.CreateAsync(customer, cancellationToken);
        var result = mapper.Map<CreateCustomerResult>(createdCustomer);
        return result;
    }
}