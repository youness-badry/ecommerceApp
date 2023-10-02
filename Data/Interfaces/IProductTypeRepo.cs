using EcommerceApplication.Entities;

namespace EcommerceApplication.Data.Interfaces
{
    public interface IProductTypeRepo
    {
        List<ProductType> GetAllProductTypes();
        void CreateProductType(ProductType productType);
        ProductType GetProductTypeById(int id);
        void updateProductType(ProductType productType);
        void DeleteProductType(ProductType productType);
        bool SaveChanges();
    }
}
