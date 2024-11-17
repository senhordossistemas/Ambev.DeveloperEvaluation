namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public sealed record CartItemRequest(Guid ProductId, int Quantity);