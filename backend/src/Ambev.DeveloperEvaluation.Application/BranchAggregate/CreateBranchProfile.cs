using Ambev.DeveloperEvaluation.Domain.Models.BranchAggregate.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.BranchAggregate;

public class CreateBranchProfile : Profile
{
    public CreateBranchProfile()
    {
        CreateMap<CreateBranchCommand, Branch>()
            .ReverseMap();
        CreateMap<Branch, CreateBranchResult>().ReverseMap();
    }
}