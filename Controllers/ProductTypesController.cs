using AutoMapper;
using EcommerceApplication.Data;
using EcommerceApplication.Data.Interfaces;
using EcommerceApplication.Dtos;
using EcommerceApplication.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeRepo _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductTypesController(IProductTypeRepo productTypeRepo, IMapper mapper)
        {
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetProductType")]
        public ActionResult<ProductType> GetProductType(int id)
        {
            var type = _productTypeRepo.GetProductTypeById(id);
            return Ok(type);
        }

        [HttpGet]
        public ActionResult<List<ProductType>> GetAllProductTypes()
        {
            var types = _productTypeRepo.GetAllProductTypes();
            return Ok(types);

        }

        [HttpPost]
        public ActionResult<ProductType> CreateProductType(ProductTypeCreateDto productTypeCreateDto)
        {
            var productType = _mapper.Map<ProductType>(productTypeCreateDto);
            _productTypeRepo.CreateProductType(productType);
            _productTypeRepo.SaveChanges();
            return CreatedAtRoute(nameof(GetProductType), new { id = productType.Id }, productType);

        }


    }
}
