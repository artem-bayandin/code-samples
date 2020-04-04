using CrossCutting.Automapper.Base;
using Domain.Entities;
using System;

namespace Application.Common.Models
{
    public class ProductModel : IMapFrom<Product>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public ProductCategoryModel ProductCategory { get; set; }
    }
}
