using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using CrossCutting.FluentValidation;
using Domain.Common.Models;
using Domain.Common.Errors;

namespace Domain.Common.Validators
{
    public class ProductLineItemModelValidator : AbstractValidator<ProductLineItemModel>
    {
        private readonly IShopContext _context;

        public ProductLineItemModelValidator(IShopContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .MustAsync(ProductExists)
                .WithFormattedMessage(CommonCustomFormatterErrors.EntityShouldExist, nameof(Product));

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage(CommonErrors.ShouldBeGreaterThan0);
        }

        private async Task<bool> ProductExists(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Products.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
