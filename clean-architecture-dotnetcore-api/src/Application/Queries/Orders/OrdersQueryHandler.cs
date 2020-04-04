using Application.QueryModels;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Orders
{
    public class OrdersQueryHandler : IRequestHandler<OrdersQuery, List<OrderModel>>
    {
        private readonly IShopContext _context;
        private readonly IMapper _mapper;

        public OrdersQueryHandler(IShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderModel>> Handle(OrdersQuery request, CancellationToken cancellationToken)
        {
            var data = await _context
                .Orders
                .Include(x => x.ProductLineItems).ThenInclude(pli => pli.Product)
                .OrderByDescending(t => t.DateCreated)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<OrderModel>>(data);
        }
    }
}
