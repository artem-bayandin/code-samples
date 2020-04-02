using Application.QueryModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class ProductCategoriesQuery : IRequest<List<ProductCategoryModel>>
    {
        // empty query

        public class ProductCategoriesQueryHandler : IRequestHandler<ProductCategoriesQuery, List<ProductCategoryModel>>
        {
            private readonly IRepository _repo;
            private readonly IMapper _mapper;

            public ProductCategoriesQueryHandler(IRepository repo, IMapper mapper)
            {
                _repo = repo;
                _mapper = mapper;
            }

            public async Task<List<ProductCategoryModel>> Handle(ProductCategoriesQuery request, CancellationToken cancellationToken)
            {
                return await _repo
                    .Set<ProductCategory>()
                    .ProjectTo<ProductCategoryModel>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
