using Application.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Products
{
    public class ProductsQuery : IRequest<List<ProductModel>>
    {
        // empty query
    }
}
