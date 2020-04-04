using Application.QueryModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Queries.OrderWithProducts
{
    public class OrderWithProductsQueryHandler : IRequestHandler<OrderWithProductsQuery, OrderWithProductsModel>
    {
        private readonly IShopContext _context;
        private readonly IMapper _mapper;

        public OrderWithProductsQueryHandler(IShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderWithProductsModel> Handle(OrderWithProductsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context
                .Orders
                .Include(x => x.ProductLineItems).ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return _mapper.Map<OrderWithProductsModel>(data);
        }
    }
}
