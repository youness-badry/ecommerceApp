using EcommerceApplication.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Dtos
{
    public class ProductCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        public int ProductTypeId { get; set; }

        public int BrandId { get; set; }
    }
}
