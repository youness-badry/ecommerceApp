using EcommerceApplication.Data;
using EcommerceApplication.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductsController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = _productRepo.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productRepo.GetProductById(id);
            return Ok(product);
        }
    }
}
