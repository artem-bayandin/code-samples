using Domain.Interfaces;
using FluentValidation;
using System.Linq;
using CrossCutting.FluentValidation;
using Domain.Common.Validators;

namespace Domain.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        private readonly IShopContext _context;

        public CreateOrderCommandValidator(IShopContext context)
        {
            _context = context;

            RuleFor(x => x.Products)
                .NotEmpty()
                .WithMessage(CreateOrderCommandErrors.OrderShouldContainAtLeastOneProduct);

            RuleForEach(x => x.Products)
                .SetValidator(new ProductLineItemModelValidator(context))
                .When(x => x.Products != null && x.Products.Any());
        }
    }
}
