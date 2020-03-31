using Application.QueryModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class ProductCategoriesQuery : IRequest<List<ProductCategoryModel>>
    {
        // empty query

        public class ProductCategoriesQueryHandler : IRequestHandler<ProductCategoriesQuery, List<ProductCategoryModel>>
        {
            private readonly ShopContext _context;
            private readonly IMapper _mapper;

            public ProductCategoriesQueryHandler(ShopContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ProductCategoryModel>> Handle(ProductCategoriesQuery request, CancellationToken cancellationToken)
            {
                return await _context
                    .ProductCategories
                    .ProjectTo<ProductCategoryModel>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken);
            }
        }
    }

    public class OrdersQuery : IRequest<List<OrderModel>>
    {
        // empty query

        public class OrdersQueryHandler : IRequestHandler<OrdersQuery, List<OrderModel>>
        {
            private readonly ShopContext _context;
            private readonly IMapper _mapper;

            public OrdersQueryHandler(ShopContext context, IMapper mapper)
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

    public class OrderWithProductsQuery : IRequest<OrderWithProductsModel>
    {
        public Guid Id { get; set; }

        // TODO: add validation

        public class OrderWithProductsQueryHandler : IRequestHandler<OrderWithProductsQuery, OrderWithProductsModel>
        {
            private readonly ShopContext _context;
            private readonly IMapper _mapper;

            public OrderWithProductsQueryHandler(ShopContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<OrderWithProductsModel> Handle(OrderWithProductsQuery request, CancellationToken cancellationToken)
            {
                var order = await _context
                    .Orders
                    .Include(x => x.ProductLineItems).ThenInclude(pli => pli.Product)
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                return _mapper.Map<OrderWithProductsModel>(order);
            }
        }
    }
}
