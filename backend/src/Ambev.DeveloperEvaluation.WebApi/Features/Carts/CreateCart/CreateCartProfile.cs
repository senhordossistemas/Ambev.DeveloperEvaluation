using Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateCart;
using Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.UpdateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartProfile : Profile
{
    public CreateCartProfile()
    {
        CreateMap<CreateCartRequest, CreateCartCommand>().ReverseMap();
        CreateMap<CartItemRequest, AddOrUpdateCartItemCommand>().ReverseMap();
        CreateMap<CreateCartResult, CreateCartResponse>().ReverseMap();
    }
}