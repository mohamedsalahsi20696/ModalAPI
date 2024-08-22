using AutoMapper;
using Modal.Domain.DTO;
using Modal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal.Domain.AutoMapper
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(des => des.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(des => des.PictureURL, opt => opt.MapFrom(src => $"{"https://localhost:7206"}/{src.PictureURL}"))
                .ReverseMap();

            CreateMap<Category, CategoryToReturnDTO>().ReverseMap();
            CreateMap<Brand, BrandToReturnDTO>().ReverseMap();
            CreateMap<Product, ProductInsertDTO>().ReverseMap();

        }
    }
}
