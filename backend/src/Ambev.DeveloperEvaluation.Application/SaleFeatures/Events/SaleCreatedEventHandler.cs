using Ambev.DeveloperEvaluation.Application.Abstractions.Messaging;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Events;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Events;

public class SaleCreatedEventHandler : IDomainEventHandler<SaleCreatedEvent>
{
    public async Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}