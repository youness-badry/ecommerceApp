using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Entities
{
    public class Product : BaseEntity<int>, IEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required] [MaxLength(1000)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public string PictureUrl { get; set; }
        public int SubSubCategoryId { get; set; }
        public SubSubCategory SubSubCategory { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

       
    }
}
