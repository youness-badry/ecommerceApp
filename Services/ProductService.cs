using AutoMapper;
using EcommerceApplication.Data;
using EcommerceApplication.Data.Interfaces;
using EcommerceApplication.Dtos;
using EcommerceApplication.Entities;
using EcommerceApplication.Exceptions;
using EcommerceApplication.RequestFeatures;
using EcommerceApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public Product CreateProduct(ProductCreateDto productCreateDto)
        {
            var newProduct = _mapper.Map<Product>(productCreateDto);
            _productRepo.Create(newProduct);
            _productRepo.SaveChanges();
            return newProduct;
        }

        public Product GetProductById(int id)
        {
            return _productRepo.FindByCondition(pr => pr.Id == id)
                .Include(pr => pr.Brand)
                .Include(pr => pr.ProductType)
                .FirstOrDefault();
        }

        public (IEnumerable<Product> products, MetaData metaData) GetProductsWithPaging(ProductParameters productParameters)
        {
            var productsWithMetaData = _productRepo.GetProductsWithPaging(productParameters);

            return (products: productsWithMetaData, metaData: productsWithMetaData.MetaData);

        }

        public (IEnumerable<Product> products, MetaData metaData) GetProductsWithFilterAndPaging(ProductParameters productParameters)
        {
            if (!productParameters.ValidPriceRange)
                throw new MaxPriceRangeBadRequestException();

            var productsWithMetaData = _productRepo.GetProductsWithFilterAndPaging(productParameters);

            return (products: productsWithMetaData, metaData: productsWithMetaData.MetaData);

        }

        public (IEnumerable<Product> products, MetaData metaData) SearchProducts(ProductParameters productParameters)
        {
            var productsSearchedWithMetaData = _productRepo.SearchProducts(productParameters);

            return (products: productsSearchedWithMetaData, metaData: productsSearchedWithMetaData.MetaData);
        }
    }
}
