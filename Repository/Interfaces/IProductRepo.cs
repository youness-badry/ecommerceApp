using EcommerceApplication.Entities;
using EcommerceApplication.RequestFeatures;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EcommerceApplication.Data.Interfaces
{
    public interface IProductRepo : IRepositoryBase<Product>
    {
        /* Basic CRUD methods are defined in IRepositoryBase */
        PagedList<Product> GetProductsWithPaging(ProductParameters productParameters);
        PagedList<Product> GetProductsWithFilterAndPaging(ProductParameters productParameters);
        public PagedList<Product> SearchProducts(ProductParameters productParameters);
        Product GetProductById(int id);

    }
}
