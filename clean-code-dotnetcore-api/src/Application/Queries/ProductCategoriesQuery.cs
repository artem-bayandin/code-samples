using Application.QueryModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            private readonly IShopContext _context;
            private readonly IMapper _mapper;

            public ProductCategoriesQueryHandler(IShopContext context, IMapper mapper)
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
}
