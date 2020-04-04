using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;
using CrossCutting.FluentValidation;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Common.Errors;

namespace Domain.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IShopContext _context;

        public CreateProductCommandValidator(IShopContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(CommonErrors.ShouldNotBeEmpty)
                .MustAsync(ShouldBeUniqueName)
                .WithMessage(CommonErrors.ShouldBeUnique);

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage(CommonErrors.ShouldBeGreaterThan0);

            RuleFor(x => x.ProductCategoryId)
                .MustAsync(ProductCategoryExists)
                .WithFormattedMessage(CommonCustomFormatterErrors.EntityShouldExist, nameof(ProductCategory));
        }

        private async Task<bool> ProductCategoryExists(Guid productCategoryId, CancellationToken cancellationToken)
        {
            return await _context.ProductCategories.AnyAsync(x => x.Id == productCategoryId, cancellationToken);
        }

        private async Task<bool> ShouldBeUniqueName(string name, CancellationToken cancellationToken)
        {
            return !(await _context.Products.AnyAsync(x => x.Name == name, cancellationToken));
        }
    }
}
