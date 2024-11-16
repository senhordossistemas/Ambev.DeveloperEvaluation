﻿using Ambev.DeveloperEvaluation.Application.BranchAggregate;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;

public class CreateBranchProfile : Profile
{
    public CreateBranchProfile()
    {
        CreateMap<CreateBranchRequest, CreateBranchCommand>().ReverseMap();
        CreateMap<CreateBranchResult, CreateBranchResponse>().ReverseMap();
    }
}