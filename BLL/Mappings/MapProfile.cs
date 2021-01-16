using AutoMapper;
using BLL.DTOs.Product;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductListDTO>();
            CreateMap<Product, ProductCUDTO>();
            CreateMap<ProductCUDTO, Product>();

            CreateMap<Shop, ShopListDTO>()
                .ForMember(dest => dest.Type,
                           opt => opt.MapFrom(src => src.Type.Name));
            CreateMap<ShopCUDTO, Shop>();
            CreateMap<Shop, ShopCUDTO>();
        }
    }
}
