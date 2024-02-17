using AutoMapper;
using Business.Dtos;
using Business.Request.Brand;
using Business.Response.Brand;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class BrandMapperProfile : Profile
    {
        public BrandMapperProfile()
        {
            CreateMap<Brand, AddBrandRequest>().ReverseMap();
            CreateMap<AddBrandResponse, Brand>().ReverseMap();
            CreateMap<IList<Brand>, GetBrandListResponse>().
                        ForMember(dest => dest.BrandListDtos,
                                    opt => opt.MapFrom(src => src));

            CreateMap<Brand, BrandListDto>().ReverseMap();
        }
    }
}
