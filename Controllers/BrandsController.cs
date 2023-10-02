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
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepo _brandRepo;
        private readonly IMapper _mapper;

        public BrandsController(IBrandRepo brandRepo, IMapper mapper)
        {
            _brandRepo = brandRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Brand>> GetBrands()
        {
            var productBrands = _brandRepo.GetAllBrands();
            return Ok(productBrands);
        }

        [HttpGet("{id}", Name = "GetBrand")]
        public ActionResult<Brand> GetBrand(int id)
        {
            var brand = _brandRepo.GetBrandById(id);
            return Ok(brand);
        }

        [HttpPost]
        public ActionResult<Brand> CreateBrand(BrandCreateDto brandCreateDto)
        {
            var newBrand = _mapper.Map<Brand>(brandCreateDto);
            _brandRepo.CreateBrand(newBrand);
            _brandRepo.SaveChanges();
            return CreatedAtRoute(nameof(GetBrand), new { id = newBrand.Id }, newBrand);

        }



    }
}
