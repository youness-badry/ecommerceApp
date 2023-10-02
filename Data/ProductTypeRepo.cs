using EcommerceApplication.Data.Interfaces;
using EcommerceApplication.Entities;

namespace EcommerceApplication.Data
{
    public class ProductTypeRepo : IProductTypeRepo
    {
        private readonly StoreContext _storeContext;

        public ProductTypeRepo(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public void CreateProductType(ProductType productType)
        {
            _storeContext.ProductTypes.Add(productType);
        }

        public void DeleteProductType(ProductType productType)
        {
            throw new NotImplementedException();
        }

        public List<ProductType> GetAllProductTypes()
        {
            return _storeContext.ProductTypes.ToList();
        }

        public ProductType GetProductTypeById(int id)
        {
            return _storeContext.ProductTypes.Find(id);
        }

        public bool SaveChanges()
        {
            return (_storeContext.SaveChanges() >= 0);
        }

        public void updateProductType(ProductType productType)
        {
            throw new NotImplementedException();
        }
    }
}
