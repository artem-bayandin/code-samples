using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ProductCategory
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public virtual List<Product> Products { get; protected set; }

        protected ProductCategory()
        {
            Products = new List<Product>();
        }

        public static ProductCategory Create(string name) => Create(name, Guid.NewGuid());

        public static ProductCategory Create(string name, Guid id)
        {
            return new ProductCategory
            {
                Id = id,
                Name = name
            };
        }
    }
}
