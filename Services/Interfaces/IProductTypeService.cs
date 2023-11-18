using EcommerceApplication.Dtos;
using EcommerceApplication.Entities;

namespace EcommerceApplication.Services.Interfaces
{
    public interface IProductTypeService
    {
        public List<ProductType> GetAllProductTypes();
        public ProductType GetProductType(int id);
        public ProductType CreateProductType(ProductTypeCreateDto productTypeCreateDto);
    }
}
