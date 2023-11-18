using EcommerceApplication.Data.Interfaces;
using EcommerceApplication.Entities;

namespace EcommerceApplication.Data
{
    public class ProductTypeRepo : RepositoryBase<ProductType>, IProductTypeRepo
    {
        private readonly StoreContext _storeContext;

        public ProductTypeRepo(StoreContext storeContext) : base(storeContext)
        {
            _storeContext = storeContext;
        }

        
    }
}
