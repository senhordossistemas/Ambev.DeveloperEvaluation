using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Dtos;
using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateCart;

public class CreateCartProfile : Profile
{
    public CreateCartProfile()
    {
        CreateMap<CreateCartCommand, Cart>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
            .ReverseMap();

        CreateMap<CartItemDto, CartItem>().ReverseMap();

        CreateMap<Cart, CreateCartResult>().ReverseMap();
    }
}