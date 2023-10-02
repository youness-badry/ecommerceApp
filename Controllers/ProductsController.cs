using AutoMapper;
using EcommerceApplication.Data.Interfaces;
using EcommerceApplication.Dtos;
using EcommerceApplication.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = _productRepo.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productRepo.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(ProductCreateDto productCreateDto)
        {
            var newProduct = _mapper.Map<Product>(productCreateDto);
            _productRepo.CreateProduct(newProduct);
            _productRepo.SaveChanges();
            return CreatedAtRoute(nameof(GetProduct), new { id = newProduct.Id }, newProduct);

        }
    }
}
