using AutoMapper;
using EcommerceApplication.Data;
using EcommerceApplication.Data.Interfaces;
using EcommerceApplication.Dtos;
using EcommerceApplication.Entities;
using EcommerceApplication.RequestFeatures;
using EcommerceApplication.Services.Interfaces;

namespace EcommerceApplication.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepo _brandRepo;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepo brandRepo, IMapper mapper)
        {
            _brandRepo = brandRepo;
            _mapper = mapper;
        }

        public Brand CreateBrand(BrandCreateDto brandCreateDto)
        {
            var newBrand = _mapper.Map<Brand>(brandCreateDto);
            _brandRepo.Create(newBrand);
            _brandRepo.SaveChanges();
            return newBrand;
        }

        public (IEnumerable<Brand> brands, MetaData metaData) GetBrandsWithPaging(BrandParameters brandParameters)
        {
            var brandsWithMetaData = _brandRepo.GetBrandsWithPaging(brandParameters);
            return (brands: brandsWithMetaData, metaData: brandsWithMetaData.MetaData); 
        }

        public Brand GetBrandById(int id)
        {
            return _brandRepo.GetBrandById(id);
            
        }
    }
}
