using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Dtos
{
    public class ProductTypeCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
