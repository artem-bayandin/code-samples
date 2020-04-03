using Application.QueryModels;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Orders
{
    public class OrdersQuery : IRequest<List<OrderModel>>
    {
        // empty query
    }
}
