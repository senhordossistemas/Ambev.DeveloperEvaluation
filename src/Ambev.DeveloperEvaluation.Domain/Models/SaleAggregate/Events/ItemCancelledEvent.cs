﻿using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Events;

public record ItemCancelledEvent(Sale Sale, SaleItem Item) : IDomainEvent;