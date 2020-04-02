using Application.QueryModels;
using AutoMapper;
using CrossCutting.FluentValidation;
using FluentValidation;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Queries
{
    public class OrderWithProductsQuery : IRequest<OrderWithProductsModel>
    {
        public Guid Id { get; set; }

        public enum OrderWithProductsQueryErrors
        {
            [Description("Id should not be empty")]
            EmptyOrderId,

            [Description("Order with id '{0}' does not exist")]
            OrderDoesNotExist
        }

        public class OrderWithProductsQueryValidator : AbstractValidator<OrderWithProductsQuery>
        {
            private readonly IRepository _repo;

            public OrderWithProductsQueryValidator(IRepository repo)
            {
                _repo = repo;

                // this does not work
                //ValidatorOptions.PropertyNameResolver = CamelCasePropertyNameResolver.ResolvePropertyName;

                RuleFor(x => x.Id)
                    .NotEmpty()
                    .WithMessage(OrderWithProductsQueryErrors.EmptyOrderId)
                    .MustAsync(OrderExists)
                    .WithMessage((query, id) => ValidatorMessageExtensions.FormatMessage(OrderWithProductsQueryErrors.OrderDoesNotExist, id));
            }

            private async Task<bool> OrderExists(Guid orderId, CancellationToken cancellationToken)
            {
                return await _repo.Set<Order>().AnyAsync(x => x.Id == orderId, cancellationToken);
            }
        }

        public class OrderWithProductsQueryHandler : IRequestHandler<OrderWithProductsQuery, OrderWithProductsModel>
        {
            private readonly IRepository _repo;
            private readonly IMapper _mapper;

            public OrderWithProductsQueryHandler(IRepository repo, IMapper mapper)
            {
                _repo = repo;
                _mapper = mapper;
            }

            public async Task<OrderWithProductsModel> Handle(OrderWithProductsQuery request, CancellationToken cancellationToken)
            {
                var order = await _repo
                    .Set<Order>()
                    .Include(x => x.ProductLineItems).ThenInclude(pli => pli.Product)
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                return _mapper.Map<OrderWithProductsModel>(order);
            }
        }
    }
}
