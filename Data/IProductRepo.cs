using EcommerceApplication.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EcommerceApplication.Data
{
    public interface IProductRepo
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        bool SaveChanges();
        void updateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
