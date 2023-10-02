using EcommerceApplication.Data.Interfaces;
using EcommerceApplication.Entities;

namespace EcommerceApplication.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly StoreContext _storeContext;

        public ProductRepo(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public void CreateProduct(Product product)
        {
            _storeContext.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            return _storeContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _storeContext.Products.Find(id);
        }

        public bool SaveChanges()
        {
            return (_storeContext.SaveChanges() >= 0);
        }

        public void updateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
