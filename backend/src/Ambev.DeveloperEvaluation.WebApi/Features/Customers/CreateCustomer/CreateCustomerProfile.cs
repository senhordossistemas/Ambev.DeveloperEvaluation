using Ambev.DeveloperEvaluation.Application.CustomerAggregate;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

public class CreateCustomerProfile : Profile
{
    public CreateCustomerProfile()
    {
        CreateMap<CreateCustomerRequest, CreateCustomerCommand>().ReverseMap();
        CreateMap<CreateCustomerResult, CreateCustomerResponse>().ReverseMap();
    }
}