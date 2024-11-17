using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;
using Ambev.DeveloperEvaluation.MessageBroker.Common;

namespace Ambev.DeveloperEvaluation.MessageBroker.Messages;

public interface ISaleUpdated : IResponse
{
    public Sale Sale { get; set; }
}