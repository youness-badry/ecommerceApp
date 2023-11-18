using EcommerceApplication.Dtos;
using EcommerceApplication.Entities;
using EcommerceApplication.RequestFeatures;
using EcommerceApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EcommerceApplication.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery] ProductParameters productParameters)
        {
            var pagedProducts = _productService.GetProductsWithPaging(productParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedProducts.metaData));
            return Ok(pagedProducts.products);
        }

        [HttpGet("filter")]
        public IActionResult GetProductsWithFilter([FromQuery] ProductParameters productParameters) 
        {
            var productsFiltered = _productService.GetProductsWithFilterAndPaging(productParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(productsFiltered.metaData));
            return Ok(productsFiltered.products);
        }

        [HttpGet("search")]
        public IActionResult SearchProducts([FromQuery] ProductParameters productParameters)
        {
            var productsAfterSearch = _productService.SearchProducts(productParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(productsAfterSearch.metaData));
            return Ok(productsAfterSearch.products);

        }


        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(ProductCreateDto productCreateDto)
        {
            if (productCreateDto == null)
            {
                return BadRequest("productCreateDto object is null");
            } 
            if (productCreateDto.ProductTypeId <= 0 || productCreateDto.ProductTypeId == null)
            {
                return BadRequest("The value of ProductType's Id of Product is incorrect");
            }
            if (productCreateDto.BrandId <= 0 || productCreateDto.BrandId == null)
            {
                return BadRequest("The value of Brand's Id of Product is incorrect");
            }

            var createdProduct = _productService.CreateProduct(productCreateDto);
            return CreatedAtRoute(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);

        }
    }
}
