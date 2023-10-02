using EcommerceApplication.Entities;

namespace EcommerceApplication.Data.Interfaces
{
    public interface IBrandRepo
    {
        List<Brand> GetAllBrands();
        Brand GetBrandById(int id);
        void CreateBrand(Brand productBrand);
        void updateBrand(Brand productBrand);
        void DeleteBrand(Brand productBrand);
        bool SaveChanges();


    }
}
