using EcommerceApplication.Entities;

namespace EcommerceApplication.Data
{
    public class ImplProductRepo : IProductRepo
    {
        private readonly StoreContext _storeContext;

        public ImplProductRepo(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void updateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
