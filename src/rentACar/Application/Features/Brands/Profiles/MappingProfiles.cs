﻿using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles;

internal class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreatedBrandDto>().ReverseMap();
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<Brand, BrandListDto>().ReverseMap();
        CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
        CreateMap<Brand, BrandGetByIdDto>().ReverseMap();
    }
}