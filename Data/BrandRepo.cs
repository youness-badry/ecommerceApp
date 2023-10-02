using EcommerceApplication.Data.Interfaces;
using EcommerceApplication.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Data
{
    public class BrandRepo : IBrandRepo
    {
        private readonly StoreContext _storeContext;

        public BrandRepo(StoreContext storeContext) 
        {
            _storeContext = storeContext;
        }
        public void CreateBrand(Brand productBrand)
        {
            _storeContext.Brands.Add(productBrand);
        }

        public void DeleteBrand(Brand productBrand)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAllBrands()
        {
            return _storeContext.Brands.ToList();
        }

        public Brand GetBrandById(int id)
        {
            return _storeContext.Brands.Find(id);

        }

        public bool SaveChanges()
        {
            return (_storeContext.SaveChanges() >= 0);
        }

        public void updateBrand(Brand productBrand)
        {
            throw new NotImplementedException();
        }
    }
}
