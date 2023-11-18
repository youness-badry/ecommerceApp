

using AutoMapper;
using EcommerceApplication.Dtos;
using EcommerceApplication.Entities;

namespace EcommerceApplication.Profiles
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<BrandCreateDto, Brand>();
            CreateMap<ProductTypeCreateDto, ProductType>();
            CreateMap<UserForRegistrationDto, User>();
        }


    }
}
