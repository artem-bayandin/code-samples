using CrossCutting.Automapper;
using Domain.Entities;
using System;

namespace Application.QueryModels
{
    public class ProductCategoryModel : IMapFrom<ProductCategory>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
