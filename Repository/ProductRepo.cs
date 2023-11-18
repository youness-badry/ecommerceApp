using EcommerceApplication.Data.Interfaces;
using EcommerceApplication.Entities;
using EcommerceApplication.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.Data
{
    public class ProductRepo : RepositoryBase<Product>, IProductRepo
    {
        private readonly StoreContext _storeContext;

        public ProductRepo(StoreContext storeContext) : base(storeContext) 
        {
            _storeContext = storeContext;
        }

        public Product GetProductById(int id)
        {
            return FindByCondition(product => product.Id == id).SingleOrDefault();
        }

        public PagedList<Product> GetProductsWithPaging(ProductParameters productParameters)
        {
            var products = FindAll()
                .OrderBy(pr => pr.Name)
                .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                .Take(productParameters.PageSize)
                .Include(pr => pr.Brand)
                .Include(pr => pr.ProductType)
                .ToList();

            var count = FindAll().Count();

            return new PagedList<Product>(products, count, productParameters.PageNumber, productParameters.PageSize);


        }

        public PagedList<Product> GetProductsWithFilterAndPaging(ProductParameters productParameters)
        {
            var productsFiltered = FindByCondition(pr => pr.Price >= productParameters.MinPrice 
                                            && pr.Price <= productParameters.MaxPrice)
                                .OrderBy(pr => pr.Name)
                                .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                                .Take(productParameters.PageSize)
                                .Include(pr => pr.Brand)
                                .Include(pr => pr.ProductType)
                                .ToList();

            var count = FindByCondition(pr => pr.Price >= productParameters.MinPrice
                                            && pr.Price <= productParameters.MaxPrice).Count();

            return new PagedList<Product>(productsFiltered, count, productParameters.PageNumber, productParameters.PageSize);


        }

        public PagedList<Product> SearchProducts(ProductParameters productParameters)
        {
            List<Product> productsSearched;
            int count;

            if (string.IsNullOrWhiteSpace(productParameters.SearchTerm))
            {

                productsSearched = FindAll()
                                    .OrderBy(pr => pr.Name)
                                    .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                                    .Take(productParameters.PageSize)
                                    .Include(pr => pr.Brand)
                                    .Include(pr => pr.ProductType)
                                    .ToList();

                count = FindAll().Count();
            }
            else
            {
                string searchTerm = productParameters.SearchTerm.Trim().ToLower();

                productsSearched = FindByCondition(pr => pr.Name.ToLower().Contains(searchTerm))
                                    .OrderBy(pr => pr.Name)
                                    .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                                    .Take(productParameters.PageSize)
                                    .Include(pr => pr.Brand)
                                    .Include(pr => pr.ProductType)
                                    .ToList();

                count = FindByCondition(pr => pr.Name.ToLower().Contains(searchTerm)).Count();
            }


            return new PagedList<Product>(productsSearched, count, productParameters.PageNumber, productParameters.PageSize);

        }

    }
}
