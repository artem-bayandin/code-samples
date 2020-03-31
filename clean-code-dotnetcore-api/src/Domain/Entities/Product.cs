using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Guid ProductCategoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual List<ProductLineItem> ProductLineItems { get; set; }

        public Product()
        {
            ProductLineItems = new List<ProductLineItem>();
        }
    }
}
