using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.DeleteCart;

public sealed record DeleteCartCommand(Guid Id) : IRequest<bool>;