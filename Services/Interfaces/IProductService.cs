using EcommerceApplication.Data.Interfaces;
using EcommerceApplication.Dtos;
using EcommerceApplication.Entities;
using EcommerceApplication.RequestFeatures;

namespace EcommerceApplication.Services.Interfaces
{
    public interface IProductService
    {
        (IEnumerable<Product> products, MetaData metaData) GetProductsWithPaging(ProductParameters productParameters);
        (IEnumerable<Product> products, MetaData metaData) GetProductsWithFilterAndPaging(ProductParameters productParameters);
        (IEnumerable<Product> products, MetaData metaData) SearchProducts(ProductParameters productParameters);
        public Product GetProductById(int id);
        public Product CreateProduct(ProductCreateDto productCreateDto);

    }
}
