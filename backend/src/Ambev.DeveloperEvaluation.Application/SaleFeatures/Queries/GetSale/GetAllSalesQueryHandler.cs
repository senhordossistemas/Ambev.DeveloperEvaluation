using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Queries.GetSale;

public class GetAllSalesQueryHandler(ISaleRepository saleRepository, IMapper mapper)
    : IRequestHandler<GetAllSalesQuery, IEnumerable<GetSaleResult>>
{
    public async Task<IEnumerable<GetSaleResult>> Handle(GetAllSalesQuery query, CancellationToken cancellationToken)
    {
        var sales = await saleRepository.GetAsync(cancellationToken);
        return mapper.Map<GetSaleResult[]>(sales);
    }
}