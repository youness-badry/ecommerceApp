using EcommerceApplication.Dtos;
using EcommerceApplication.Entities;
using EcommerceApplication.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Services.Interfaces
{
    public interface IBrandService
    {
        public (IEnumerable<Brand> brands, MetaData metaData) GetBrandsWithPaging(BrandParameters brandParameters);
        public Brand GetBrandById(int id);
        public Brand CreateBrand(BrandCreateDto brandCreateDto);
    }
}
