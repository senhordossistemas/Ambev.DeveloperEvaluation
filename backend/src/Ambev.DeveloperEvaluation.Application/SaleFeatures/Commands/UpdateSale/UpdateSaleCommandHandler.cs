using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Commands.UpdateSale;

public class UpdateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper)
    : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await saleRepository.GetByIdAsync(command.Id, cancellationToken) 
                   ?? throw new Exception($"Sale with Id {command.Id} not found.");

        sale.UpdateSaleDetails(command.TotalAmount, command.IsCancelled, command.CustomerId, command.BranchId);
        sale.UpdateItems(command.Items);

        sale.Calculate();
        sale.UpdateTimestamp();

        var updatedSale = await saleRepository.UpdateAsync(sale, cancellationToken);

        return mapper.Map<UpdateSaleResult>(updatedSale);
    }
}