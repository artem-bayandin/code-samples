using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public double Price { get; protected set; }

        public Guid ProductCategoryId { get; protected set; }

        public virtual ProductCategory ProductCategory { get; protected set; }
        public virtual List<ProductLineItem> ProductLineItems { get; protected set; }

        protected Product()
        {
            ProductLineItems = new List<ProductLineItem>();
        }

        public static Product Create()
        {
            return new Product
            {
                Id = Guid.NewGuid()
            };
        }
    }
}
