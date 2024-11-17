using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Queries.GetSale;

public sealed record GetAllSalesQuery : IRequest<IEnumerable<GetSaleResult>>;