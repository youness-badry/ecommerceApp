using EcommerceApplication.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EcommerceApplication.Data.Interfaces
{
    public interface IProductRepo
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void updateProduct(Product product);
        void DeleteProduct(Product product);
        bool SaveChanges();

    }
}
