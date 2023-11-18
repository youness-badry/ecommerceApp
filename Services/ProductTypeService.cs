using AutoMapper;
using EcommerceApplication.Data.Interfaces;
using EcommerceApplication.Dtos;
using EcommerceApplication.Entities;
using EcommerceApplication.Services.Interfaces;

namespace EcommerceApplication.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepo _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductTypeService(IProductTypeRepo productTypeRepo, IMapper mapper)
        {
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        public ProductType CreateProductType(ProductTypeCreateDto productTypeCreateDto)
        {
            var newProductType = _mapper.Map<ProductType>(productTypeCreateDto);
            _productTypeRepo.Create(newProductType);
            _productTypeRepo.SaveChanges();
            return newProductType;
        }

        public List<ProductType> GetAllProductTypes()
        {
            return _productTypeRepo.FindAll().ToList();
        }

        public ProductType GetProductType(int id)
        {
            return _productTypeRepo.FindByCondition(productType =>  productType.Id == id).FirstOrDefault();
        }
    }
}
