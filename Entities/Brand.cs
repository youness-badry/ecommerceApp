using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Entities
{
    public class Brand : BaseEntity<int>, IEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
