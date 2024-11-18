using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models.CustomerAggregate.Entities;

public class Customer : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string ExternalId { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
}