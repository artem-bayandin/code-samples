using Application.QueryModels;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.ProductCategories
{
    public class ProductCategoriesQuery : IRequest<List<ProductCategoryModel>>
    {
        // empty query
    }
}
