﻿namespace EcommerceApplication.Entities
{
    public class SubSubCategory : BaseEntity<int>, IEntity
    {
        public string Name { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

    }
}
