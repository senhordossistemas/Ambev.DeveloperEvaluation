using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.UpdateCart;

public sealed record AddOrUpdateCartItemCommand(Guid UserId, Guid ProductId, int Quantity
) : IRequest<UpdateCartResult>
{
    public AddOrUpdateCartItemCommand() : this(Guid.Empty, Guid.Empty, default) { }
}

