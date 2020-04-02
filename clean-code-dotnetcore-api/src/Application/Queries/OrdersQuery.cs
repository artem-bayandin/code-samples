using Application.QueryModels;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class OrdersQuery : IRequest<List<OrderModel>>
    {
        // empty query

        public class OrdersQueryHandler : IRequestHandler<OrdersQuery, List<OrderModel>>
        {
            private readonly IRepository _repo;
            private readonly IMapper _mapper;

            public OrdersQueryHandler(IRepository repo, IMapper mapper)
            {
                _repo = repo;
                _mapper = mapper;
            }

            public async Task<List<OrderModel>> Handle(OrdersQuery request, CancellationToken cancellationToken)
            {
                var data = await _repo
                    .Set<Order>()
                    .Include(x => x.ProductLineItems).ThenInclude(pli => pli.Product)
                    .OrderByDescending(t => t.DateCreated)
                    .ToListAsync(cancellationToken);

                return _mapper.Map<List<OrderModel>>(data);
            }
        }
    }
}
