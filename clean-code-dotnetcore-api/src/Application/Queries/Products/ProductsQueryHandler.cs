using Application.QueryModels;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Products
{
    public class ProductsQueryHandler : IRequestHandler<ProductsQuery, List<ProductModel>>
    {
        private readonly IShopContext _context;
        private readonly IMapper _mapper;

        public ProductsQueryHandler(IShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductModel>> Handle(ProductsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context
                .Products
                .Include(x => x.ProductCategory)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<ProductModel>>(data);
        }
    }
}
