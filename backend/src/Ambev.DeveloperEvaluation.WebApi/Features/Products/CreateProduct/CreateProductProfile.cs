using Ambev.DeveloperEvaluation.Application.ProductAggregate;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>().ReverseMap();
        CreateMap<CreateProductResult, CreateProductResponse>().ReverseMap();
    }
}