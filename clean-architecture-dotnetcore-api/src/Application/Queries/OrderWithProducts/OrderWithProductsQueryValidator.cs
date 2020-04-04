using CrossCutting.FluentValidation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Common.Errors;

namespace Application.Queries.OrderWithProducts
{
    public class OrderWithProductsQueryValidator : AbstractValidator<OrderWithProductsQuery>
    {
        private readonly IShopContext _context;

        public OrderWithProductsQueryValidator(IShopContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(CommonErrors.ShouldNotBeEmpty)
                .MustAsync(OrderExists)
                .WithMessage((query, id) => ValidatorMessageExtensions.FormatMessage(OrderWithProductsQueryErrors.OrderDoesNotExist, id));
        }

        private async Task<bool> OrderExists(Guid orderId, CancellationToken cancellationToken)
        {
            return await _context.Orders.AnyAsync(x => x.Id == orderId, cancellationToken);
        }
    }
}
