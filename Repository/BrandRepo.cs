using EcommerceApplication.Data.Interfaces;
using EcommerceApplication.Entities;
using EcommerceApplication.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Data
{
    public class BrandRepo : RepositoryBase<Brand>, IBrandRepo
    {
        private readonly StoreContext _storeContext;
        public BrandRepo(StoreContext storeContext) : base(storeContext)
        {
            _storeContext = storeContext;
        }

        public Brand GetBrandById(int id)
        {
            return FindByCondition(brand => brand.Id == id).SingleOrDefault();
        }

        public PagedList<Brand> GetBrandsWithPaging(BrandParameters brandParameters)
        {
            var items =  FindAll()
                .OrderBy(br => br.Name)
                .Skip((brandParameters.PageNumber - 1) * brandParameters.PageSize)
                .Take(brandParameters.PageSize)
                .ToList();

            var count = FindAll().Count();

            return new PagedList<Brand>(items, count, brandParameters.PageNumber, brandParameters.PageSize);
        }
    }
}
