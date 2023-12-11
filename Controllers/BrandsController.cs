using AutoMapper;
using EcommerceApplication.Data;
using EcommerceApplication.Data.Interfaces;
using EcommerceApplication.Dtos;
using EcommerceApplication.Entities;
using EcommerceApplication.Exceptions;
using EcommerceApplication.RequestFeatures;
using EcommerceApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EcommerceApplication.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult GetBrands([FromQuery] BrandParameters brandParameters)
        {
            var pagedBrands = _brandService.GetBrandsWithPaging(brandParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedBrands.metaData));
            return Ok(pagedBrands.brands);
        }

        [HttpGet("{id}", Name = "GetBrand")]
        public ActionResult<Brand> GetBrand(int id)
        {
            var brand = _brandService.GetBrandById(id);
            if(brand == null)
            {
                throw new BrandNotFoundException(id);
            }
            return Ok(brand);
        }


        [HttpPost]
        public ActionResult<Brand> CreateBrand(BrandCreateDto brandCreateDto)
        {
            if(brandCreateDto is null)
            {
                return BadRequest("BrandCreateDto object is null");
            }

            var createdBrand = _brandService.CreateBrand(brandCreateDto);

            return CreatedAtRoute(nameof(GetBrand), new { id = createdBrand.Id }, createdBrand);

        }



    }
}
