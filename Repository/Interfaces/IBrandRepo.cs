using EcommerceApplication.Entities;
using EcommerceApplication.RequestFeatures;

namespace EcommerceApplication.Data.Interfaces
{
    public interface IBrandRepo : IRepositoryBase<Brand> { 
        
        /* Basic CRUD methods are defined in IRepositoryBase */
        PagedList<Brand> GetBrandsWithPaging(BrandParameters brandParameters);
        Brand GetBrandById(int id);
        


    }
}
