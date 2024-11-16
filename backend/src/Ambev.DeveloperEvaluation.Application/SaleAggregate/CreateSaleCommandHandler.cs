﻿using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleAggregate;

public class CreateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper)
    : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = mapper.Map<Sale>(command);

        var createdSale = await saleRepository.CreateAsync(user, cancellationToken);
        var result = mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }
}