using Application.QueryModels;
using AutoMapper;
using CrossCutting.FluentValidation;
using FluentValidation;
using Infrastructure.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class OrderWithProductsQuery : IRequest<OrderWithProductsModel>
    {
        public Guid Id { get; set; }

        public enum OrderWithProductsQueryErrors
        {
            [Description("Order with id '{0}' does not exist")]
            OrderDoesNotExist
        }

        public class OrderWithProductsQueryValidator : AbstractValidator<OrderWithProductsQuery>
        {
            private readonly ShopContext _context;

            public OrderWithProductsQueryValidator(ShopContext context)
            {
                _context = context;

                // this does not work
                //ValidatorOptions.PropertyNameResolver = CamelCasePropertyNameResolver.ResolvePropertyName;

                RuleFor(x => x.Id)
                    .MustAsync(OrderExists)
                    .WithMessage((query, id) => ValidatorMessageExtensions.FormatMessage(query, id, OrderWithProductsQueryErrors.OrderDoesNotExist));
                    //.WithMessage(OrderWithProductsQueryErrors.OrderDoesNotExist);
            }

            private async Task<bool> OrderExists(Guid orderId, CancellationToken cancellationToken)
            {
                return await _context.Orders.AnyAsync(x => x.Id == orderId, cancellationToken);
            }
        }

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
