using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Entities
{
    public class SubCategory : BaseEntity<int>, IEntity
    {
        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
