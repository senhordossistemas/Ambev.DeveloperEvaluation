using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.UpdateCart;

public class UpdateCartProfile : Profile
{
    public UpdateCartProfile()
    {
        CreateMap<Cart, UpdateCartResult>().ReverseMap();
    }
}