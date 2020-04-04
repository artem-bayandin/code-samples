using CrossCutting.Automapper.Base;
using Domain.Entities;
using System;

namespace Application.Common.Models
{
    public class ProductCategoryModel : IMapFrom<ProductCategory>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
