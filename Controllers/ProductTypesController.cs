using EcommerceApplication.Dtos;
using EcommerceApplication.Entities;
using EcommerceApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypesController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet("{id}", Name = "GetProductType")]
        public ActionResult<ProductType> GetProductType(int id)
        {
            var type = _productTypeService.GetProductType(id);
            return Ok(type);
        }

        [HttpGet]
        public ActionResult<List<ProductType>> GetAllProductTypes()
        {
            var types = _productTypeService.GetAllProductTypes();
            return Ok(types);

        }

        [HttpPost]
        public ActionResult<ProductType> CreateProductType(ProductTypeCreateDto productTypeCreateDto)
        {
            if (productTypeCreateDto is null)
                return BadRequest("productTypeCreateDto object is null");

            var createdProductType = _productTypeService.CreateProductType(productTypeCreateDto);
            return CreatedAtRoute(nameof(GetProductType), new { id = createdProductType.Id }, createdProductType);

        }


    }
}
