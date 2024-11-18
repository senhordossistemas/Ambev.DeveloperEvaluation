using Ambev.DeveloperEvaluation.Application.CustomerFeatures;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
///     Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CreateUserProfile : Profile
{
    /// <summary>
    ///     Initializes the mappings for CreateUser feature
    /// </summary>
    public CreateUserProfile()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>();
        CreateMap<CreateCustomerRequest, CreateCustomerCommand>()
            .ForMember(dest => dest.UserCommand, opt => opt.MapFrom(src => src.UserRequest));
        CreateMap<CreateUserResult, CreateUserResponse>();
    }
}