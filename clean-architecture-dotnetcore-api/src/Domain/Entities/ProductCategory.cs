using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ProductCategory
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }

        public ProductCategory()
        {
            Products = new List<Product>();
        }
    }
}
