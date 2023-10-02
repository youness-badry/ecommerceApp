using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Entities
{
    public class ProductType : BaseEntity<int>, IEntity
    {
        [Required]
        public string Name { get; set; }
    }
}