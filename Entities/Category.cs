using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Entities
{
    public class Category : BaseEntity<int>, IEntity
    {
        [Required]
        public string Name { get; set; }

    }
}
