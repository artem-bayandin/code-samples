using Application.QueryModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.ProductCategories
{
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
            var data = await _context
                .ProductCategories
                .OrderBy(x => x.Name)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<ProductCategoryModel>>(data);
        }
    }
}
