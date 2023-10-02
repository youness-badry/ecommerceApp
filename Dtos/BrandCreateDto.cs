using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Dtos
{
    public class BrandCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
